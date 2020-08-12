using UnityEngine;
using System.Collections;

public class SuperString 
{
	public string STR ="noname";
	string STR_DEFAULT ="noname";
	string KEY = "unitystl";

	public SuperString(string initv, string key)
	{
		KEY = key;
		STR = initv;
		STR_DEFAULT = initv;
		Load ();
	}

	public void Set(string x)
	{
		STR = x;
	}

	
	public void Save()
	{
		PlayerPrefs.SetString (KEY, STR);
	}
	public void Load()
	{
		STR = PlayerPrefs.GetString (KEY, STR_DEFAULT);
	}
	public void Clear()
    {
		PlayerPrefs.DeleteKey(KEY);

	}
}
