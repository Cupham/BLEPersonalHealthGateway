using UnityEngine;
using System.Collections;

public class UserInformation
{
    public static DeviceSaveInfo DEVICESAVEINFO;
    public static UserSaveInfo USERSAVEINFO;
    public static SuperInt CURRENT_USER_ID;

   static UserInformation()
    {
        CURRENT_USER_ID = new SuperInt(-1, "currentuser");
        USERSAVEINFO = new UserSaveInfo("user");
        USERSAVEINFO.Xuat();
        DEVICESAVEINFO = new DeviceSaveInfo("gfv"); 
#if UNITY_EDITOR
        if(DEVICESAVEINFO.N.Get()<=1)
        DEVICESAVEINFO.AddDeviceInfo("1111111", "222222","181d");

        string s = "";
        //foreach (characteristicUUIDInfo i in LISTS_OBTAINED)
        {
            s += "aaaa" + "," + "bbbbb"+ "," + "sdfsd f " + "\n";
            s += "aaaa2" + "," + "bbbbb2" + "," + "sdfsd f " + "\n";
        }
        DEVICESAVEINFO.DEVICES[0].INFO.STR = s;
        DEVICESAVEINFO.DEVICES[0].Save();
#endif
    }

}

