using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharateristicItem : MonoBehaviour
{
    //static public bool is_busy_global = false;
    public Text TEXT1;
    public Text TEXT2;
    public Text TEXT_BUTTON;
    public string address; public string serviceUUID; public string characteristicUUID;
    public bool is_get_info = false;
    void Start()
    {

    }
    public void Init(string address, string serviceUUID, string characteristicUUID)
    {
        is_get_info = false;
        this.address = address;
        this.serviceUUID = serviceUUID;
        this.characteristicUUID = characteristicUUID;
        TEXT1.text = serviceUUID + " " + characteristicUUID;

        //if(BLEManager.I.TOGGLE_AUTO.isOn)
           // OnClick();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
       // is_busy_global = true;
        Debug.Log("TOAN101: CLicking " + serviceUUID + " " + characteristicUUID);
        if(BLEManager.I.IsEqual(characteristicUUID,"2a9d")||
            BLEManager.I.IsEqual(characteristicUUID, "2a03")||
            BLEManager.I.IsEqual(characteristicUUID, "2a05")
            )
        {
            BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress(address, serviceUUID, characteristicUUID, 
                (noti, noti2) =>
                {
                    is_get_info = true;
                   // is_busy_global = false;
                    Debug.Log("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address);
                    BLEManager.I.MyLog("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address);
                }, 
                (address, characteristicUUID, bytes) =>
                 {
                Debug.Log("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address);
                BLEManager.I.MyLog("TOAN5555: SubscribeCharacteristicWithDeviceAddress to " + address);
                     string data = "";
                foreach (var b in bytes)
                    data += b.ToString("X") + " ";
                TEXT2.text = data;
                TEXT1.text += " ***** ";
                is_get_info = true;
              //  is_busy_global = false;
                 }
                );
        }
        else BluetoothLEHardwareInterface.ReadCharacteristic(address, serviceUUID, characteristicUUID, (characteristicUUID2, bytes) =>
        {
            Debug.Log("TOAN189: ReadCharacteristic to " + characteristicUUID2 + " : " + "OK");
            BLEManager.I.MyLog("TOAN189: ReadCharacteristic to " + characteristicUUID2 + " : " + "OK");
            string data = "";
            foreach (var b in bytes)
                data += b.ToString("X") + " ";
            TEXT2.text = data;
            is_get_info = true;
           // is_busy_global = false;
        });
    }
}
