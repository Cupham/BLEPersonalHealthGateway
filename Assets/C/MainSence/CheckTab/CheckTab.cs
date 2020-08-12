using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTab : MonoBehaviour
{
    public static DeviceInfo DEVICEINFO;
    public static CheckTab I;
    void Awake()
    {
        if (DEVICEINFO == null && UserInformation.DEVICESAVEINFO.N.Get() > 0)
            DEVICEINFO = UserInformation.DEVICESAVEINFO.DEVICES[0];
        I = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
}
