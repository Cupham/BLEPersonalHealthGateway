/* This is a simple example to show the steps and one possible way of
 * automatically scanning for and connecting to a device to receive
 * notification data from the device.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BLEManager : MonoBehaviour
{
	void Awake()
    {
		I = this;
		item_demo.gameObject.SetActive(false);

	}
	public static BLEManager I;
	public Text TEXT_LOG;
	public string DeviceName = "A&D";
	public string ServiceUUID = "2a9d";
	public string SubscribeCharacteristic = "2a9d";
	public string WriteCharacteristic = "2a9d";
	public string[] ServiceUUIDlist = { "2a19", "2a00" };
	
	enum States
	{
		None,
		Scan,
		ScanRSSI,
		Connect,
		Subscribe,
		Unsubscribe,
		Disconnect,
	}

	private bool _connected = false;
	private float _timeout = 0f;
	private States _state = States.None;
	private string _deviceAddress;
	private bool _foundSubscribeID = false;
	private bool _foundWriteID = false;
	private byte[] _dataBytes = null;
	private bool _rssiOnly = false;
	private int _rssi = 0;
	List<string> LOG_LIST = new List<string>();
	public void MyLog(string s)
    {
		LOG_LIST.Add(s);
		while(LOG_LIST.Count>9)
        {
			LOG_LIST.RemoveAt(0);
		}
		string s2 = "";
		foreach(string i in LOG_LIST)
        {
			s2 += i + "\n";
        }
		TEXT_LOG.text = s2;
	}

	bool _is_get_auto = false;
	void Reset()
	{
		INFOs.Clear();
		_is_get_auto = false;
		_connected = false;
		_timeout = 0f;
		_state = States.None;
		_deviceAddress = null;
		_foundSubscribeID = false;
		_foundWriteID = false;
		_dataBytes = null;
		_rssi = 0;
	}

	void SetState(States newState, float timeout)
	{
		_state = newState;
		_timeout = timeout;
	}

	void StartProcess()
	{
		Reset();
		BluetoothLEHardwareInterface.Initialize(true, false, () => 
		{
			SetState(States.Scan, 0.1f);
			MyLog("Scanning");

		}, (error) => {

			BluetoothLEHardwareInterface.Log("Error during initialize: " + error);
			MyLog("Error during initialize: " + error);
			if (current_item != null)
			{
				current_item.is_get_info = true;
				current_item.TEXT2.text = "Error";
			}
		});
	}

	// Use this for initialization
	void Start()
	{
		//StartCoroutine(GetAllInfor(0.05f));
		//AddCharaterisItem("a", "b", "c");
		StartProcess();
	}

	// Update is called once per frame
	List<CharaterisInfo> INFOs = new List<CharaterisInfo>();
	void Update()
	{
		if (_timeout > 0f)
		{
			_timeout -= Time.deltaTime;
			if (_timeout <= 0f)
			{
				_timeout = 0f;

				switch (_state)
				{
					case States.None:
						break;

					case States.Scan:
						BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (address, name) => {
							if (!_rssiOnly)
							{
								Debug.Log("TOAN1: Scanned " + name);
								if (name.Contains(DeviceName))
								{
									BluetoothLEHardwareInterface.StopScan();

									// found a device with the name we want
									// this example does not deal with finding more than one
									_deviceAddress = address;
									SetState(States.Connect, 0.5f);
								}

							}

						}, (address, name, rssi, bytes) => {

							// use this one if the device responses with manufacturer specific data and the rssi
							Debug.Log("TOAN2: Scanned " + name);
							MyLog("Scanned " + name);
							if (name.Contains(DeviceName))
							{
								if (_rssiOnly)
								{
									_rssi = rssi;
								}
								else
								{
									BluetoothLEHardwareInterface.StopScan();
									_deviceAddress = address;
									SetState(States.Connect, 0.5f);
								}
							}

						}, _rssiOnly); // this last setting allows RFduino to send RSSI without having manufacturer data

						if (_rssiOnly)
							SetState(States.ScanRSSI, 0.5f);
						break;

					case States.ScanRSSI:
						break;

					case States.Connect:
						// set these flags
						_foundSubscribeID = false;
						_foundWriteID = false;

						// note that the first parameter is the address, not the name. I have not fixed this because
						// of backwards compatiblity.
						// also note that I am note using the first 2 callbacks. If you are not looking for specific characteristics you can use one of
						// the first 2, but keep in mind that the device will enumerate everything and so you will want to have a timeout
						// large enough that it will be finished enumerating before you try to subscribe or do any other operations.
//#if UNITY_IOS
//						Debug.Log("TOAN: Changed address from " + _deviceAddress + " to");
//						_deviceAddress = "5C:31:3E:03:5E:B7";
//#endif
						if(!_is_get_auto && TOGGLE_AUTO.isOn)
                        {
							_is_get_auto = true;
							MyLog("Starting StartCoroutine after 4 seconds");
							StartCoroutine(GetAllInfor(4f));

						}
						Debug.Log("TOAN3: Trying to connect to address " + _deviceAddress);
						MyLog("Trying to connect to address " + _deviceAddress);
						BluetoothLEHardwareInterface.ConnectToPeripheral(_deviceAddress, (connectAction) =>
						{
							Debug.Log("TOAN1441: Connect OK to " + connectAction);
							MyLog("Connected to address " + connectAction);
						},
						(serviceAction, serviceActio2) =>
						{
							Debug.Log("TOAN1442: " + serviceAction + " " + serviceActio2);
							MyLog("Finish getting information: " + serviceAction+ " " + serviceActio2);
							if(_is_get_auto==false)
								_is_get_auto = true;
						}
						, (address, serviceUUID2, characteristicUUID) =>
						{
							Debug.Log("TOAN1444:  " + address + " ; " + serviceUUID2 + " ; " + characteristicUUID);
							MyLog("Found UUID: " + serviceUUID2 + " ;characteristicUUID=" + characteristicUUID); 
							CharateristicItem i =  AddCharaterisItem(address,serviceUUID2, characteristicUUID);
							INFOs.Add(new CharaterisInfo(address, serviceUUID2, characteristicUUID,i));

						},
							(s1) =>
							{
								Debug.Log("TOAN1445: DISCONNECTED");
								MyLog("DISCONNECTED");
							});
						break;

					case States.Subscribe:
						BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(_deviceAddress, ServiceUUID, SubscribeCharacteristic, null, (address, characteristicUUID, bytes) =>
						{
							Debug.Log("TOAN5: SubscribeCharacteristicWithDeviceAddress to " + _deviceAddress);
							_state = States.None;
							_dataBytes = bytes;
						});
						break;

					case States.Unsubscribe:
						Debug.Log("TOAN6: Unsubscribe to " + _deviceAddress);
						BluetoothLEHardwareInterface.UnSubscribeCharacteristic(_deviceAddress, ServiceUUID, SubscribeCharacteristic, null);
						SetState(States.Disconnect, 4f);
						break;

					case States.Disconnect:
						Debug.Log("TOAN7: Disconnect to " + _deviceAddress);
						if (_connected)
						{
							BluetoothLEHardwareInterface.DisconnectPeripheral(_deviceAddress, (address) => {
								BluetoothLEHardwareInterface.DeInitialize(() => {

									_connected = false;
									_state = States.None;
								});
							});
						}
						else
						{
							BluetoothLEHardwareInterface.DeInitialize(() => {

								_state = States.None;
							});
						}
						break;
				}
			}
		}
	}
	public void OnClickGetAll()
    {
		//_is_get_auto = true;
		StartCoroutine(GetAllInfor(0.05f));
	}
	CharateristicItem current_item = null;
	private IEnumerator GetAllInfor(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		MyLog("Starting StartCoroutine now");
		{
            foreach (CharaterisInfo i in INFOs)
            {
				current_item = i.ITEM;

				i.ITEM.OnClick();
                while (!i.ITEM.is_get_info)
                    yield return new WaitForSeconds(0.005f);
            }
        }
	}




	private bool ledON = false;
	public void OnLED()
	{
		ledON = !ledON;
		if (ledON)
		{
			SendByte((byte)0x01);
		}
		else
		{
			SendByte((byte)0x00);
		}
	}

	string FullUUID(string uuid)
	{
		return "0000" + uuid + "-0000-1000-8000-00805f9b34fb";
	}

	public bool IsEqual(string uuid1, string uuid2)
	{
		if (uuid1.Length == 4)
			uuid1 = FullUUID(uuid1);
		if (uuid2.Length == 4)
			uuid2 = FullUUID(uuid2);

		return (uuid1.ToUpper().CompareTo(uuid2.ToUpper()) == 0);
	}

	void SendByte(byte value)
	{
		byte[] data = new byte[] { value };
		BluetoothLEHardwareInterface.WriteCharacteristic(_deviceAddress, ServiceUUID, WriteCharacteristic, data, data.Length, true, (characteristicUUID) => {

			BluetoothLEHardwareInterface.Log("Write Succeeded");
		});
	}

	void OnGUI()
	{
		GUI.skin.textArea.fontSize = 32;
		GUI.skin.button.fontSize = 32;
		GUI.skin.toggle.fontSize = 32;
		GUI.skin.label.fontSize = 32;

		if (_connected)
		{
			if (_state == States.None)
			{
				if (GUI.Button(new Rect(10, 10, Screen.width - 10, 100), "Disconnect"))
					SetState(States.Unsubscribe, 1f);

				if (GUI.Button(new Rect(10, 210, Screen.width - 10, 100), "Write Value"))
					OnLED();

				if (_dataBytes != null)
				{
					string data = "";
					foreach (var b in _dataBytes)
						data += b.ToString("X") + " ";

					GUI.TextArea(new Rect(10, 400, Screen.width - 10, 300), data);
				}
			}
			else if (_state == States.Subscribe && _timeout == 0f)
			{
				GUI.TextArea(new Rect(50, 100, Screen.width - 100, Screen.height - 200), "Press the button on the RFduino");
			}
		}
		else if (_state == States.ScanRSSI)
		{
			if (GUI.Button(new Rect(10, 10, Screen.width - 10, 100), "Stop Scanning"))
			{
				BluetoothLEHardwareInterface.StopScan();
				SetState(States.Disconnect, 0.5f);
			}

			if (_rssi != 0)
				GUI.Label(new Rect(10, 300, Screen.width - 10, 50), string.Format("RSSI: {0}", _rssi));
		}
		else if (_state == States.None)
		{
			if (GUI.Button(new Rect(10, 10, Screen.width - 10, 100), "Connect"))
				StartProcess();

			_rssiOnly = GUI.Toggle(new Rect(10, 200, Screen.width - 10, 50), _rssiOnly, "Just Show RSSI");
		}
	}
	public Toggle TOGGLE_AUTO;
	public CharateristicItem item_demo;
	List<GameObject> G = new List<GameObject>();
	public CharateristicItem AddCharaterisItem(string address, string serviceUUID, string characteristicUUID)
	{
		//Debug.Log("AddCharaterisItem");
		item_demo.gameObject.SetActive(false);
		CharateristicItem i = MonoBehaviour.Instantiate(item_demo);
		i.Init(address, serviceUUID, characteristicUUID);
		i.transform.SetParent(item_demo.transform.parent);

		i.gameObject.SetActive(true);
		i.transform.localScale = Vector3.one;
		G.Add(i.gameObject);

		return i;
	}
	public void OnCLickStartScan()
    {
		foreach (GameObject g in G) Destroy(g);
		G.Clear();
		StartProcess();
	}
}

public class CharaterisInfo
{
	string address; string serviceUUID; string characteristicUUID;
	public CharateristicItem ITEM;
	public CharaterisInfo(string address, string serviceUUID, string characteristicUUID, CharateristicItem ITEM=null)
	{
		this.address = address;
		this.serviceUUID = serviceUUID;
		this.characteristicUUID = characteristicUUID;
		this.ITEM = ITEM;
	}
}