using UnityEngine;
using System.Collections;

public class SuperInt 
{
	public int NUM =0;
	int NUM_DEFAULT =0;
	string KEY = "unitystt";
	public SuperInt(int initv, string key)
	{
		KEY = key;
		NUM = initv;
		NUM_DEFAULT = initv;
		Load ();
	}
	public int Get()
	{
		return NUM;
	}
	public void Set(int x)
	{
		NUM = x;
	}
	public void SetAndSave(int x)
	{
		NUM = x;
		Save ();
	}
	public void Plus(int x)
	{
		NUM += x;
	}
	public void PlusAndSave(int x)
	{
		NUM += x;
		Save ();
	}
	public void Save()
	{
		PlayerPrefs.SetInt (KEY, NUM);
	}
    public void Load()
    {
        NUM = PlayerPrefs.GetInt(KEY, NUM_DEFAULT);
    }
	public void Clear()
    {
		PlayerPrefs.DeleteKey(KEY);
	}
}
