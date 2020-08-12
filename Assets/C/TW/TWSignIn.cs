using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class TWSignIn : TWBoard
{
	public InputField TEXTFIELD_USERNAME;
	public InputField TEXTFIELD_PASS1;
	
	void Start () 
    {
        base.InitTWBoard();
	}
	void Update () 
    {
	
	}
	public void OnClickSignIn()
    {
		foreach(UserInfo i in UserInformation.USERSAVEINFO.USERS)
        {
			if(i.USER.STR.Equals(TEXTFIELD_USERNAME.text))
            {
				if (i.PASS.STR.Equals(TEXTFIELD_PASS1.text))
                {
					UserInformation.CURRENT_USER_ID.SetAndSave(UserInformation.USERSAVEINFO.USERS.IndexOf(i));
					UserTab.I.Start();
					ClickX();
					return;
                }
				TW.I.AddWarning("", "Wrong password!");
				return;
			}
        }
		TW.I.AddWarning("", "Username doesn't exist! ");
	}
    
}
