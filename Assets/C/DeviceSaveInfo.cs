using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DeviceSaveInfo
{
    public SuperInt N;
    public List<DeviceInfo> DEVICES;
    public string KEY;
    public DeviceSaveInfo(string key)
    {
        KEY = key;
        Load(); 
        
    }
    public void AddDeviceInfo(string mac, string name, string service_uuid)
    {
        foreach (DeviceInfo i in DEVICES)
            if (i.MAC.STR.Equals(mac)) return;

        DEVICES.Add(new DeviceInfo(KEY + N.Get() + "h", mac, name, service_uuid));
        DEVICES[DEVICES.Count - 1].Save();
        N.SetAndSave(DEVICES.Count);
    }
    public void Load()
    {
        N = new SuperInt(0, KEY + "nn"); 
        DEVICES = new List<DeviceInfo>(); 
        for (int i =0; i< N.Get(); i++)
        {
            DeviceInfo d = new DeviceInfo(KEY + i + "h");
            DEVICES.Add(d);
        }
    }
    public void Remove(DeviceInfo item)
    {
        Remove(DEVICES.IndexOf(item));
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= N.Get()) return;
        DeviceInfo ditem = DEVICES[index];
        ditem.Clear();
        DEVICES.RemoveAt(index);
        for (int i = index; i < DEVICES.Count; i++)
        {
            DEVICES[i].SaveForce(KEY + i + "h");
        }
        N.SetAndSave(DEVICES.Count);
    }
    public void Xuat()
    {
        string s = "";
        for (int i = 0; i < N.Get(); i++)
        {
            s += "[" + DEVICES[i].MAC.STR + "," + DEVICES[i].NAME.STR + "," + "" + "] ";
        }
        Debug.Log(s);
    }
    public void Clear()
    {
        N.SetAndSave(0);
        DEVICES.Clear();
    }
    public List<DeviceInfo> CloneLIST()
    {
        List<DeviceInfo> c = new List<DeviceInfo>();
        foreach (DeviceInfo s in DEVICES)
            c.Add(s);
        return c;
    }
    public DeviceInfo GetDeviceInfobyID(string mac)
    {
        foreach (DeviceInfo h in DEVICES)
            if (h.MAC.STR == mac) return h;
        return null;
    }

   
}

public class DeviceInfo : IComparable<DeviceInfo>
{
    public SuperString ID;
    public SuperString MAC;
    public SuperString NAME;
    public SuperString INFO;
    public SuperString SERVICE_UUID;
    public string KEY;
    public DeviceInfo(string key, string mac, string name,string service_uuid)
    {
        KEY = key;
        ID =  new SuperString("", KEY + ":K");
        MAC = new SuperString(mac, KEY + ":I");
        NAME = new SuperString(name, KEY + ":L");
        INFO = new SuperString("", KEY + ":F");
        SERVICE_UUID = new SuperString("", KEY + ":S");
        Save();

    }
    public DeviceInfo(string key)
    {
        KEY = key;
        ID = new SuperString("", KEY + ":K");
        MAC = new SuperString("", KEY + ":I");
        NAME = new SuperString("", KEY + ":L");
        INFO = new SuperString("", KEY + ":F");
        SERVICE_UUID = new SuperString("", KEY + ":S");
        Save();
    }
 
    public void Load()
    {
        ID.Load();
        MAC.Load();
        NAME.Load();
        INFO.Load();
        SERVICE_UUID.Load();
    }
    public void Save()
    {
        ID.Save(); 
        MAC.Save();
        NAME.Save();
        INFO.Save();
        SERVICE_UUID.Save();
    }
    public void SaveForce(string newkey)
    {
        KEY = newkey;
        ID.Save();
        MAC.Save();
        NAME.Save();
        INFO.Save();
        SERVICE_UUID.Save();
    }
    public void Clear()
    {
        ID.Clear();
        MAC.Clear();
        NAME.Clear();
        INFO.Clear();
        SERVICE_UUID.Clear();
    }

    public int CompareTo(DeviceInfo obj)
    {
        //if (LEVEL.Get() + LEVEL_PRE.Get()  < obj.LEVEL.Get() + obj.LEVEL_PRE.Get()) return 1;
        //if (LEVEL.Get() + LEVEL_PRE.Get() > obj.LEVEL.Get() + obj.LEVEL_PRE.Get()) return -1;
        //if(DUST.Get() < obj.DUST.Get()) return 1;
        //if (DUST.Get() > obj.DUST.Get()) return -1;
        //if (DUST.Get() < obj.DUST.Get()) return 1;


        //if (ST_ROLE_INFO != null && obj.ST_ROLE_INFO != null)
        //{
        //    if (ST_ROLE_INFO.star < obj.ST_ROLE_INFO.star) return 1;
        //    if (ST_ROLE_INFO.star > obj.ST_ROLE_INFO.star) return -1;
        //}
        //else
        {
            //if (ST_ROLE_INFO == null) Debug.Log("KO CO ST_ROLE_INFO_0: " + ID.Get());
            // if (obj.ST_ROLE_INFO == null) Debug.Log("KO CO ST_ROLE_INFO_1: " + obj.ID.Get());
        }
        // The orders are equivalent.
        return 0;
    }



}
