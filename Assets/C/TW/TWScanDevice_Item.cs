
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;

public class TWScanDevice_Item : MonoBehaviour
{
    public static TWScanDevice_Item CURRENT_STATIC = null;
    public Text TEXT_NAME;
    public Text TEXT_MAC;
    public Image IMAGE_ICON;
    public string address;
    public string name;
    public string data;
    public List<characteristicUUIDInfo> LISTS = new List<characteristicUUIDInfo>();
    //public List<characteristicUUIDInfo> LISTS_OBTAINED = new List<characteristicUUIDInfo>();
    public Dictionary<string,characteristicUUIDInfo> DICT_OBTAINED = new Dictionary<string,characteristicUUIDInfo>();
    bool _is_get_auto = false;
    GameObject loadingobject = null;
    public void OnClick()
    {
        loadingobject = TW.AddLoading(null, 30); 
        Debug.Log("TOAN2440: OnClick");
        DICT_OBTAINED.Clear();
        BluetoothLEHardwareInterface.StopScan();

        if (!_is_get_auto )
        {
            Debug.Log("TOAN2440: Calling StartCoroutine after 4 seconds");
            _is_get_auto = true;
            StartCoroutine(GetAllInfor(4f));
        }

        BluetoothLEHardwareInterface.ConnectToPeripheral(address, (connectAction) =>
        {
            Debug.Log("TOAN2441: Connected OK to " + connectAction);
        },
        (serviceAction, serviceActio2) =>
        {
            Debug.Log("TOAN2442: " + serviceAction + " " + serviceActio2);
        }
        , (address, serviceUUID2, characteristicUUID) =>
        {
            Debug.Log("TOAN2444:  " + address + " ; " + serviceUUID2 + " ; " + characteristicUUID);
            if(serviceUUID2.Substring(0,4).Equals("0000"))
            LISTS.Add(new characteristicUUIDInfo(address, serviceUUID2, characteristicUUID));
        },
        (s1) =>
        {
            Debug.Log("TOAN2445: DISCONNECTED");
        });
    }
    private IEnumerator GetAllInfor(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
            CURRENT_STATIC = this;
            Debug.Log("TOAN2446: Trying to read " + LISTS.Count + " characteristics" );
            int c = 0;
            foreach (characteristicUUIDInfo i in LISTS)
            {
                is_get_info = false;
                GetAllCharacteristics(i.address, i.serviceUUID, i.characteristicUUID);
                while (!is_get_info)
                    yield return new WaitForSeconds(0.05f);
                c++;
                Debug.Log("TOAN2447: Got " +c + "/" + LISTS.Count +" "+ i.characteristicUUID);
            }
        }
        //if (loadingobject != null) Destroy(loadingobject);
        //TW.I.AddWarning("", "Obtained " + DICT_OBTAINED.Count + " characteristics, from address: " + address + " with name: " + name +"Current length: " + UserInformation.DEVICESAVEINFO.N.Get(), onclickyes);

        UserInformation.DEVICESAVEINFO.AddDeviceInfo(address, name, ""); 
        DeviceInfo di = UserInformation.DEVICESAVEINFO.GetDeviceInfobyID(address);
        bool[] service_found = new bool[TWScanDevice.SUPPORTED_SERVICES.Length];
        for (int i = 0; i < service_found.Length; i++)
            service_found[i] = false;

        if (di!=null)
        {
            string s = "";
            foreach (KeyValuePair<string, characteristicUUIDInfo> i in DICT_OBTAINED)
            {
                if (IsEqual(i.Value.characteristicUUID, "2a01") || IsEqual(i.Value.characteristicUUID, "2a02") ||
                    IsEqual(i.Value.characteristicUUID, "2a03") || IsEqual(i.Value.characteristicUUID, "2a04") || IsEqual(i.Value.characteristicUUID, "2a05") ||
                    IsEqual(i.Value.characteristicUUID, "2a9e") || IsEqual(i.Value.characteristicUUID, "2a2a"))
                    ;
                else if (IsEqual(i.Value.characteristicUUID, "2a19"))
                {
                    int batterry = -1;
                    int.TryParse(i.Value.DATA, System.Globalization.NumberStyles.HexNumber, null, out batterry);
                    i.Value.DATA = batterry.ToString();
                }
                else
                    i.Value.DATA = System.Text.Encoding.ASCII.GetString(i.Value.DATA_bytes);// + " (" + i.Value.DATA.Length+") "  + i.Value.DATA;

                string serviceUUID_ = i.Value.serviceUUID;
                string characteristicUUID_ = i.Value.characteristicUUID;
                if (serviceUUID_.Length >= 32) serviceUUID_ = serviceUUID_.Substring(4, 4);
                if (characteristicUUID_.Length >= 32) characteristicUUID_ = characteristicUUID_.Substring(4, 4);
                s += serviceUUID_ + "," + characteristicUUID_ + "," + i.Value.DATA + "\n";

                for (int i2 = 0; i2 < service_found.Length; i2++)
                    if (IsEqual(serviceUUID_, TWScanDevice.SUPPORTED_SERVICES[i2]))
                        service_found[i2] = true;
            }
            di.INFO.STR = s;
            di.Save();
        }
        string my_service = "";
        for (int i = 0; i < service_found.Length; i++)
        {
            if (service_found[i]) my_service = TWScanDevice.SUPPORTED_SERVICES[i];
        }
        //UserInformation.DEVICESAVEINFO.AddDeviceInfo(address, name, my_service);
        di.SERVICE_UUID.STR = my_service;
        di.Save();
        DeviceList.I.UpdateUI();

        createWeighingDevice(null, di, DICT_OBTAINED);
        //if (loadingobject != null) Destroy(loadingobject);
    }


    public void createWeighingDevice(Patient p, DeviceInfo INFO, Dictionary<string,characteristicUUIDInfo> DICT_OBTAINED)
    {
        Device device = new Device();

        //Meta
        Meta metadata = new Meta();

        metadata.VersionId= "ExampleV1";
        metadata.LastUpdated =  DateTime.Now;
        metadata.Profile = new string[] { "http://hl7.org/fhir/uv/phd/StructureDefinition/PhdDevice" };
       
        
        // Identifier
        List<Identifier> identifiers = new List<Identifier>();
        Identifier identifier = new Identifier();
        identifier.System=("http://hl7.org/fhir/sid/eui-48");
        identifier.Value = INFO.MAC.STR;
        identifier.Assigner = new ResourceReference();
        identifier.Assigner.Display = "EUI-48";

        CodeableConcept code = new CodeableConcept();
        code.Coding.Add(new Coding("http://hl7.org/fhir/uv/phd/CodeSystem/ContinuaDeviceIdentifiers", "BTMAC"));
        identifier.Type =  code;
        identifiers.Add(identifier);
        
  
        List<Device.DeviceNameComponent> deviceNames = new List<Device.DeviceNameComponent>();
        Device.DeviceNameComponent name = new Device.DeviceNameComponent();
        if (DICT_OBTAINED.ContainsKey("00002a00-0000-1000-8000-00805f9b34fb"))
            name.Name= DICT_OBTAINED["00002a00-0000-1000-8000-00805f9b34fb"].DATA;
        name.Type=(DeviceNameType.UserFriendlyName);
        deviceNames.Add(name);

        Coding coding = new Coding("http://loinc.org", "29463-7", "Body Weight");

        device.Meta = metadata;
        device.Identifier = (identifiers);
        //
        if(DICT_OBTAINED.ContainsKey("00002a29-0000-1000-8000-00805f9b34fb"))
        device.Manufacturer = DICT_OBTAINED["00002a29-0000-1000-8000-00805f9b34fb"].DATA;
        if (DICT_OBTAINED.ContainsKey("00002a25-0000-1000-8000-00805f9b34fb"))
            device.SerialNumber = DICT_OBTAINED["00002a25-0000-1000-8000-00805f9b34fb"].DATA;
        if (DICT_OBTAINED.ContainsKey("00002a24-0000-1000-8000-00805f9b34fb"))
            device.ModelNumber = DICT_OBTAINED["00002a24-0000-1000-8000-00805f9b34fb"].DATA;
        device.DeviceName = deviceNames;
        // Type
        device.Type = (new CodeableConcept("urn.iso.std.iso:11073:10101", "65573", "MDC_MOC_VMS_MDS_SIMP"));
        device.Patient = new ResourceReference("Patient/" + UserInformation.USERSAVEINFO.USERS[UserInformation.CURRENT_USER_ID.Get()].ID.Get().ToString());

        //createDeviceAsync(device);
        var client = new FhirClient("http://hapi.fhir.org/baseR4");
        var result =client.Create(device);
        INFO.ID.Set(result.Id); INFO.Save();
        TW.I.AddWarning("", "Created ID " + result.Id, onclickyes);
        
    }
    //static public async void createDeviceAsync(Device device)
    //{
    //    var client = new FhirClient("http://hapi.fhir.org/baseR4");
    //    var result = await client.CreateAsync(device);

    //    TW.I.AddWarning("", "Created ID " + result.Id); 
    //}
    void onclickyes()
    {
        FindObjectOfType<TWScanDevice>().OnClickCancel();
        if (loadingobject != null) Destroy(loadingobject);
    }
    public bool is_get_info = false;
    public void GetAllCharacteristics(string address, string serviceUUID, string characteristicUUID)
    {
        
        if (IsEqual(characteristicUUID, "2a9d") ||
            IsEqual(characteristicUUID, "2a03") ||
            IsEqual(characteristicUUID, "2a05")
            )
        {
            BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(address, serviceUUID, characteristicUUID,
                (noti, noti2) =>
                {
                    is_get_info = true;
                    Debug.Log("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address);
                },
                (address2, characteristicUUID2, bytes) =>
                {
                    Debug.Log("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address2);
                    string data = "";
                    foreach (var b in bytes)
                        data += b.ToString("X") + " ";
                    DICT_OBTAINED.Add(characteristicUUID, new characteristicUUIDInfo(address, serviceUUID, characteristicUUID, data, bytes));
                    is_get_info = true;
                }
                );
        }
        else BluetoothLEHardwareInterface.ReadCharacteristic(address, serviceUUID, characteristicUUID, (characteristicUUID2, bytes) =>
        {
            Debug.Log("TOAN189: ReadCharacteristic to " + characteristicUUID2 + " : " + "OK");
            string data = "";
            foreach (var b in bytes)
                data += b.ToString("X") + " ";
            DICT_OBTAINED.Add(characteristicUUID,new characteristicUUIDInfo(address, serviceUUID, characteristicUUID, data, bytes));
            is_get_info = true;
        });



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
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Init(string address, string name, string data = "")
    {
        name = name.Trim();
        this.name = name;
        this.address = address;
        this.data = data;
        TEXT_NAME.text = "Name: " + name;
        TEXT_MAC.text = "MAC: " + address + " " + data;
    }
}

public class characteristicUUIDInfo
{
    public characteristicUUIDInfo(string address,string serviceUUID, string characteristicUUID)
    {
        this.address = address;
        this.serviceUUID = serviceUUID;
        this.characteristicUUID = characteristicUUID;

    }
    public characteristicUUIDInfo(string address, string serviceUUID, string characteristicUUID,string DATA, byte[] DATA_bytes)
    {
        this.address = address;
        this.serviceUUID = serviceUUID;
        this.characteristicUUID = characteristicUUID;
        this.DATA = DATA;
        this.DATA_bytes = DATA_bytes;
    }
    public string address;
    public string serviceUUID;
    public string characteristicUUID;
    public string DATA;
    public byte[] DATA_bytes;
}

