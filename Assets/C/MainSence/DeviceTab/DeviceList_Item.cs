using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceList_Item : MonoBehaviour
{
    public Text TEXT_NAME;
    public Text TEXT_MAC;
    public Image IMAGE_ICON;
    DeviceInfo INFO;
    public void OnClick()
    {
        CheckTab.DEVICEINFO = INFO;
        MainSence.I.OnCLickCheck();
        WeightScale.I.DoStart();
    }
    public void OnClickInfo()
    {
        //TW.I.AddWarning("", INFO.INFO.STR); 
        TWDeviceList_Item_Option board  = TW.AddABoard("TWDeviceList_Item_Option").GetComponent<TWDeviceList_Item_Option>();
        board.Init(INFO);


    }
    void Start()
    {
        
    }

    public void Init(DeviceInfo INFO)
    {
        this.INFO = INFO;
        name = name.Trim();
        //this.name = name;
        //this.address = address;
        //this.data = data;
        TEXT_NAME.text = "Name: " + INFO.NAME.STR;
        TEXT_MAC.text = "MAC: " + INFO.MAC.STR;
        IMAGE_ICON.sprite = Resources.Load<Sprite>("Images/" + INFO.SERVICE_UUID.STR);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
