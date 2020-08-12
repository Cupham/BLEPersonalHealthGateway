using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System.Globalization;

public class TWScanDevice : TWBoard
{
	public UnityEngine.UI.Text TEXT_TITLE;
	public TWScanDevice_Item demo;

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

	public string DeviceName = "A&D";
	void Reset()
	{
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
	public void MyLog(string s)
	{
		LOG_LIST.Add(s);
		while (LOG_LIST.Count > 9)
		{
			LOG_LIST.RemoveAt(0);
		}
		string s2 = "";
		foreach (string i in LOG_LIST)
		{
			s2 += i + "\n";
		}
		//TEXT_LOG.text = s2;
	}
	//CharateristicItem current_item = null;
	void StartProcess()
	{
		Reset();
		BluetoothLEHardwareInterface.Initialize(true, false, () =>
		{
			SetState(States.Scan, 0.1f);
			MyLog("Scanning");

		}, 
		(error) => 
		{

			BluetoothLEHardwareInterface.Log("Error during initialize: " + error);
			MyLog("Error during initialize: " + error);
			if (TWScanDevice_Item.CURRENT_STATIC != null)
			{
				TWScanDevice_Item.CURRENT_STATIC.is_get_info = true;
				Debug.Log("TOAN2447: Error " + error);

			}
		});
	}
	bool _is_get_auto = false;
	void Start()
	{
		demo.gameObject.SetActive(false);
		base.InitTWBoard();
		//StartCoroutine(GetAllInfor(0.05f));
		//AddCharaterisItem("a", "b", "c");
		StartProcess();
	}

	public static string[] SUPPORTED_SERVICES = new string[] { "181D", "1809", "1810" };
void Update()
	{
		if (_timeout > 0f)
		{
			_timeout -= UnityEngine.Time.deltaTime;
			if (_timeout <= 0f)
			{
				_timeout = 0f;

				switch (_state)
				{
					case States.None:
						break;

					case States.Scan:
						BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(SUPPORTED_SERVICES, (address, name) => {
							if (!_rssiOnly)
							{
								AddTWScanDevice_Item(address, name);
								Debug.Log("TOAN1: Scanned " + name);
							}

						}, (address, name, rssi, bytes) => {

							string data = "";
							foreach (var b in _dataBytes)
								data += b.ToString("X") + " ";
							Debug.Log("TOAN2: Scanned " + name);
							MyLog("Scanned " + name);
							AddTWScanDevice_Item(address, name, data);
							
						}, _rssiOnly); // this last setting allows RFduino to send RSSI without having manufacturer data

						if (_rssiOnly)
							SetState(States.ScanRSSI, 0.5f);
						break;

					case States.ScanRSSI:
						break;

					case States.Connect:
						_foundSubscribeID = false;
						_foundWriteID = false;
						if (!_is_get_auto )
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
							MyLog("Finish getting information: " + serviceAction + " " + serviceActio2);
							if (_is_get_auto == false)
								_is_get_auto = true;
						}
						, (address, serviceUUID2, characteristicUUID) =>
						{
							Debug.Log("TOAN1444:  " + address + " ; " + serviceUUID2 + " ; " + characteristicUUID);
							MyLog("Found UUID: " + serviceUUID2 + " ;characteristicUUID=" + characteristicUUID);
						},
							(s1) =>
							{
								Debug.Log("TOAN1445: DISCONNECTED");
								MyLog("DISCONNECTED");
							});
						break;
					case States.Disconnect:
						Debug.Log("TOAN7: Disconnect to " + _deviceAddress);
						ForceDisconnect();
						break;
				}
			}
		}
	}
	CharateristicItem current_item = null;
	private IEnumerator GetAllInfor(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
	}
	List<TWScanDevice_Item> G = new List<TWScanDevice_Item>();
	public TWScanDevice_Item AddTWScanDevice_Item(string address, string name, string data="")
	{
		foreach(TWScanDevice_Item g in G)
        {
			if (g.address.Equals(address)) return null;
        }
		
		demo.gameObject.SetActive(false);
		TWScanDevice_Item i = MonoBehaviour.Instantiate(demo);
		i.Init(address, name, data);
		i.transform.SetParent(demo.transform.parent);
		i.gameObject.SetActive(true);
		i.transform.localScale = Vector3.one;
		G.Add(i);
		return i;
	}
	bool is_quit_ok = false;
	public void OnClickCancel()
    {
		ForceDisconnect();
		StartCoroutine(waittoclose());
	}
	public void OnClickSignUp()
	{
		ForceDisconnect();
		StartCoroutine(waittoclose());
	}
	IEnumerator waittoclose()
    {
		while (!is_quit_ok)
			yield return new WaitForSeconds(0.05f);
		ClickX();
    }
	void ForceDisconnect()
    {
		if (_connected)
		{
			BluetoothLEHardwareInterface.DisconnectPeripheral(_deviceAddress, (address) => {
				BluetoothLEHardwareInterface.DeInitialize(() => {
					is_quit_ok = true;
					_connected = false;
					_state = States.None;
				});
			});
		}
		else
		{
			BluetoothLEHardwareInterface.DeInitialize(() => {

				_state = States.None;
				is_quit_ok = true;
			});
		}
		Reset();
	}
}
