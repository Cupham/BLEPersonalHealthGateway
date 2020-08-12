using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserSaveInfo
{
    public SuperInt N;
    public List<UserInfo> USERS;
    public string KEY;
    public UserSaveInfo(string key)
    {
        KEY = key;
        Load();

    }
    public bool AddUserInfo(string user, string pass, int id)
    {
        foreach (UserInfo i in USERS)
        {
            if (i.ID.Get() == id) return false;
            if (i.USER.STR.Equals(user)) return false;
        }


        USERS.Add(new UserInfo(KEY + N.Get() + "h", user, pass, id));
        USERS[USERS.Count - 1].Save();
        N.SetAndSave(USERS.Count);

        return true;
    }
    public void Load()
    {
        N = new SuperInt(0, KEY + "nn");
        USERS = new List<UserInfo>();
        for (int i = 0; i < N.Get(); i++)
        {
            UserInfo d = new UserInfo(KEY + i + "h");
            USERS.Add(d);
        }
    }
    public void Remove(UserInfo item)
    {
        Remove(USERS.IndexOf(item));
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= N.Get()) return;
        UserInfo ditem = USERS[index];
        ditem.Clear();
        USERS.RemoveAt(index);
        for (int i = index; i < USERS.Count; i++)
        {
            USERS[i].SaveForce(KEY + i + "h");
        }
        N.SetAndSave(USERS.Count);
    }
    public void Xuat()
    {
        string s = "";
        for (int i = 0; i < N.Get(); i++)
        {
            s += "[" + USERS[i].USER.STR + "," + USERS[i].PASS.STR + "," + USERS[i].ID.Get() + "] ";
        }
        Debug.Log(s);
    }
    public void Clear()
    {
        N.SetAndSave(0);
        USERS.Clear();
    }
    public List<UserInfo> CloneLIST()
    {
        List<UserInfo> c = new List<UserInfo>();
        foreach (UserInfo s in USERS)
            c.Add(s);
        return c;
    }
    public UserInfo GetUserInfobyID(int id)
    {
        foreach (UserInfo h in USERS)
            if (h.ID.Get() == id) return h;
        return null;
    }
    public UserInfo GetUserInfobyIndex(int index)
    {
        return USERS[index];
    }

}

public class UserInfo : IComparable<UserInfo>
{

    public SuperString USER;
    public SuperString PASS;
    public SuperInt ID;
    public string KEY;
    public UserInfo(string key, string user, string pass, int id)
    {
        KEY = key;
        USER = new SuperString(user, KEY + ":I");
        PASS = new SuperString(pass, KEY + ":L");
        ID = new SuperInt(id, KEY + ":F");
        Save();

    }
    public UserInfo(string key)
    {
        KEY = key;
        USER = new SuperString("", KEY + ":I");
        PASS = new SuperString("", KEY + ":L");
        ID = new SuperInt(0, KEY + ":F");
        Save();
    }

    public void Load()
    {
        USER.Load();
        PASS.Load();
        ID.Load();
    }
    public void Save()
    {
        USER.Save();
        PASS.Save();
        ID.Save();
    }
    public void SaveForce(string newkey)
    {
        KEY = newkey;
        USER.Save();
        PASS.Save();
        ID.Save();
    }
    public void Clear()
    {
        USER.Clear();
        PASS.Clear();
        ID.Clear();
    }

    public int CompareTo(UserInfo obj)
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
