using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceList : MonoBehaviour
{
    public static DeviceList I;
    public DeviceList_Item demo;
    public List<DeviceList_Item> LIST = new List<DeviceList_Item>();
    void Awake()
    {
        I = this;
        demo.gameObject.SetActive(false);
    }
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (DeviceList_Item i in LIST)
        {
            Destroy(i.gameObject);

        }
        LIST.Clear();
        
        for (int i = 0; i < UserInformation.DEVICESAVEINFO.N.Get(); i++)
        {
            DeviceInfo di = UserInformation.DEVICESAVEINFO.DEVICES[i];
            AddDeviceList_Item(di);
        }
    }
    public DeviceList_Item AddDeviceList_Item(DeviceInfo INFO)
    {
        //foreach (DeviceList_Item g in G)
        //{
        //    if (g.address.Equals(address)) return null;
        //}
        demo.gameObject.SetActive(false);
        DeviceList_Item i = MonoBehaviour.Instantiate(demo);
        i.Init(INFO);
        i.transform.SetParent(demo.transform.parent);
        i.gameObject.SetActive(true);
        i.transform.localScale = Vector3.one;
        LIST.Add(i);
        return i;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
