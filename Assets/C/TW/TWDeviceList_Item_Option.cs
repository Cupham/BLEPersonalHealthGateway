using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System.Globalization;

public class TWDeviceList_Item_Option : TWBoard
{
	public GameObject demo;
	DeviceInfo DEVICEINFO;
	void Start()
	{
		base.InitTWBoard();
		demo.SetActive(false);
	}
	public void Init(DeviceInfo DEVICEINFO)
    {
		this.DEVICEINFO = DEVICEINFO;
		title.text = "Name: " + DEVICEINFO.NAME.STR + "\nMAC: " + DEVICEINFO.MAC.STR+"\nID: " + DEVICEINFO.ID.STR
			+ "; Service: " + DEVICEINFO.SERVICE_UUID.STR;

		string s = DEVICEINFO.INFO.STR;
		string[] S = s.Split('\n');

		//Debug.Log(S.Length);
		foreach(string s2 in S)
        {
			string[] S2 = s2.Split(',');
			//Debug.Log(S2.Length + " " + s2);
			if (S2.Length==3)
            {
				AddItem(S2[0], S2[1], S2[2]);

			}
        }
	}
	public void OnClickRemove()
    {
		UserInformation.DEVICESAVEINFO.Remove(DEVICEINFO);
		DeviceList.I.UpdateUI();
		ClickX();
    }
	public void AddItem(string address, string name, string data = "")
	{
		GameObject g = MonoBehaviour.Instantiate(demo);
		g.SetActive(true);
		g.transform.SetParent(demo.transform.parent);
		g.transform.localScale = Vector3.one;
		g.GetComponentInChildren<Text>().text = address + "," + name + ":" + data;
	}
}
