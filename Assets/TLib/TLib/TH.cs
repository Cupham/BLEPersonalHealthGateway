using UnityEngine;
using System.Collections;

public class TH
{ 
	static public string MEGA_LINK = "http://stgamevn.com/toan/stgame/stt/";
	public delegate void hamyes();
	public delegate void hamno();
	public static hamyes onhamyes;
	public static hamno onhamno;
    public static bool IS_ERROR = false;
	public static string STR;
	static public string GetHTML2(string uri)
	{
        IS_ERROR = false;
		WWW www = new WWW (uri);    
		
		while (!www.isDone)  //wait until www isdone
			;
		
		if (www.error != null) 
			return null;        
		return www.text;
	}
	static public void GetHTML(string uri,hamyes c,MonoBehaviour mono)
	{
        IS_ERROR = false;
		onhamyes= yes;
		onhamno =no;
		onhamyes += c;
		mono.StartCoroutine(MyLoadPage_1(uri,onhamyes));
	}
	static IEnumerator MyLoadPage_1(string url,hamyes c) 
	{
		WWW www = new WWW (url);
		yield return www;
		if (www.error == null)
        {
			STR = www.text;
			c ();
		} 
        else 
        {
            IS_ERROR = true;
            STR = "";
			c ();
            
		}
	}
	static public void GetHTML(string uri,hamyes c,hamno c2,MonoBehaviour mono)
	{
		onhamyes =yes;
		onhamno =no;
		onhamyes += c;
		onhamno += c2;
		mono.StartCoroutine(MyLoadPage(uri,onhamyes));
	}

	static IEnumerator MyLoadPage(string url,hamyes c) 
	{
		WWW www = new WWW (url);
		yield return www;
		if (www.error == null) {
			STR = www.text;
			c ();
		} else {
			STR=null;
			onhamno ();
		}
	}
	static void yes(){}
	static void no(){}
}
