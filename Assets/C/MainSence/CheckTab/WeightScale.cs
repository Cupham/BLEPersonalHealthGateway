using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using Time = UnityEngine.Time;

public class WeightScale : MonoBehaviour
{
	public static WeightScale I;
	public string ServiceUUID = "2a9d";
	public string SubscribeCharacteristic = "2a9d";
	public Text TEXT_TITLE;
    public Text TEXT_WEIGHT;
    public Text TEXT_DAY;
	public DeviceInfo DEVICEINFO;
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
	void Awake()
    {
		I = this;
    }
	public void DoStart()
    {
		DEVICEINFO = CheckTab.DEVICEINFO;
		StartProcess();
		TEXT_TITLE.text = "Starting";
		TEXT_WEIGHT.text = "";
		TEXT_DAY.text = "";
	}
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
    void StartProcess()
    {
        Reset();
        BluetoothLEHardwareInterface.Initialize(true, false, () =>
        {
            SetState(States.Scan, 0.1f);
        }, (error) => {

            BluetoothLEHardwareInterface.Log("Error during initialize: " + error);
           
        });
    }
    void SetState(States newState, float timeout)
    {
        _state = newState;
        _timeout = timeout;
    }
    void Start()
    {
		//StartCoroutine(GetAllInfor(0.05f));
		//AddCharaterisItem("a", "b", "c");
#if UNITY_EDITOR
	ShowInfo("");
#endif
    }
	bool _is_get_auto = false;
	// Update is called once per frame
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
						TEXT_TITLE.text = "Scanning device " + DEVICEINFO.MAC.STR;
						BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, (address, name) => {
							if (!_rssiOnly)
							{
								
								Debug.Log("TOAN1: Scanned " + name);
								if (address.Equals(DEVICEINFO.MAC.STR))
								{
									TEXT_TITLE.text = "Scanned device " + DEVICEINFO.MAC.STR;
									BluetoothLEHardwareInterface.StopScan();
									_deviceAddress = address;
									SetState(States.Connect, 0.5f);
								}

							}

						}, (address, name, rssi, bytes) => {

							Debug.Log("TOAN2: Scanned " + name);
							if (address.Equals(DEVICEINFO.MAC.STR))
							{
								if (_rssiOnly)
								{
									_rssi = rssi;
								}
								else
								{
									TEXT_TITLE.text = "Scanned device " + DEVICEINFO.MAC.STR;
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
						//if (!_is_get_auto)
						//{
						//	_is_get_auto = true;

						//	StartCoroutine(GetAllInfor(4f));

						//}
						TEXT_TITLE.text = "Connecting to device " + DEVICEINFO.MAC.STR;
						BluetoothLEHardwareInterface.ConnectToPeripheral(_deviceAddress, (connectAction) =>
						{
							TEXT_TITLE.text = "Connected to device " + DEVICEINFO.MAC.STR;
							Debug.Log("TOAN3441: Connect OK to " + connectAction);
						},
						(serviceAction, serviceActio2) =>
						{
							Debug.Log("TOAN3442: " + serviceAction + " " + serviceActio2);
							if (_is_get_auto == false)
								_is_get_auto = true;
						}
						, (address, serviceUUID2, characteristicUUID) =>
						{
							Debug.Log("TOAN3444:  " + address + " ; " + serviceUUID2 + " ; " + characteristicUUID);
							TEXT_TITLE.text = "Reading characteristic information ";
							if (IsEqual(characteristicUUID, "2a9d"))
                            {
								ServiceUUID = serviceUUID2;
								SubscribeCharacteristic = characteristicUUID;
								_connected = true;
								SetState(States.Subscribe, 2f);
								

							}

						},
							(s1) =>
							{
								Debug.Log("TOAN1445: DISCONNECTED");
								
							});
						break;

					case States.Subscribe:
						TEXT_TITLE.text = "Reading weight's characteristic";
						Debug.Log("TOAN3445: SubscribeCharacteristicWithDeviceAddress to " + _deviceAddress + " "+ ServiceUUID + " " + SubscribeCharacteristic);
						BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(_deviceAddress, ServiceUUID, SubscribeCharacteristic, null, (address, characteristicUUID, bytes) =>
						{
							Debug.Log("TOAN3446: SubscribeCharacteristicWithDeviceAddress to " + _deviceAddress);
							_state = States.None;
							_dataBytes = bytes;

							string data = "";
							foreach (var b in _dataBytes)
								data += b.ToString("X") + " ";

							TEXT_TITLE.text = "Weight";

							ShowInfo(data);
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
	void ShowInfo(string hex)
    {
#if UNITY_EDITOR
		hex = "02 0C 12 E4 07 08 0A 0D 25 2D";
#endif
		string postfix = "Kg";
		string[] s = hex.Split(' ');
		int s0 = 2;
		int.TryParse(s[0],out s0);
		if(s0==3) postfix = "Pound";

		int weight=-1; 
		int.TryParse(s[2]+s[1], System.Globalization.NumberStyles.HexNumber,null,out weight);

		TEXT_WEIGHT.text = weight*0.005f + postfix;

		int year = -1;
		int.TryParse(s[4] + s[3], System.Globalization.NumberStyles.HexNumber, null, out year);
		int month=-1;
		int.TryParse(s[5], System.Globalization.NumberStyles.HexNumber, null, out month);
		int day = -1;
		int.TryParse(s[6], System.Globalization.NumberStyles.HexNumber, null, out day);
		int hour = -1;
		int.TryParse(s[7], System.Globalization.NumberStyles.HexNumber, null, out hour);
		int min = -1;
		int.TryParse(s[8], System.Globalization.NumberStyles.HexNumber, null, out min);
		int sec = -1;
		int.TryParse(s[9], System.Globalization.NumberStyles.HexNumber, null, out sec);

		TEXT_DAY.text = year + "/" + (month<10?"0":"")+ month + "/" + (day < 10 ? "0" : "") + day + " " + (hour < 10 ? "0" : "") + hour + ":" + (min < 10 ? "0" : "") + min + ":" + (sec < 10 ? "0" : "") + sec;


		StartCoroutine(SendData(weight, postfix));
    }
	IEnumerator SendData(int weight, string postfix)
    {
		yield return new WaitForSeconds(0.1f);
		var client = new FhirClient("http://hapi.fhir.org/baseR4");
		Debug.Log("TOAN111: DEVICEINFO:" + DEVICEINFO.ID.STR);
		Device device = client.Read<Device>("http://hapi.fhir.org/baseR4/Device/" + DEVICEINFO.ID.STR);
		if (device != null)
		{
			Debug.Log("TOAN113: DEVICEINFO:" + DEVICEINFO.ID.STR);
			//Quantity quantityValue = new Quantity();
			Quantity quantityValue;
			if (device.Property.Count > 0 && device.Property[0].ValueQuantity.Count > 0)
				quantityValue = device.Property[0].ValueQuantity[0];
			else
				quantityValue = new Quantity();

			quantityValue.Value = (decimal)(weight * 0.005f);
			quantityValue.System = ("http://unitsofmeasure.org");
			quantityValue.Code = postfix;

			Coding weightCoding = new Coding("http://loinc.org", "29463-7", "Body Weight");
			Device.PropertyComponent weightProperty = new Device.PropertyComponent();
			CodeableConcept code = new CodeableConcept();
			code.Coding.Add(weightCoding);
			weightProperty.Type = code;
			weightProperty.ValueQuantity.Add(quantityValue);

			if (device.Property.Count == 0)
				device.Property.Add(weightProperty);
			else device.Property[0] = weightProperty;
			var result = client.Update(device);
			TW.I.AddWarning("", "Updated ID " + result.Id);
		}
		else
		{
			Debug.Log("TOAN112: DEVICEINFO:" + DEVICEINFO.ID.STR);
		}
	}
}
