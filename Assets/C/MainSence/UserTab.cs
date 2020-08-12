using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserTab : MonoBehaviour
{
    public Text TEXT_USER;
    public Transform TRANSFORM_NOT_LOGIN;
    public Transform TRANSFORM_LOGIN;
    public static UserTab I;
    void Awake()
    {
        I = this;
    }
    public void Start()
    {
        if(UserInformation.CURRENT_USER_ID.Get()==-1)
        {
            TRANSFORM_NOT_LOGIN.gameObject.SetActive(true);
            TRANSFORM_LOGIN.gameObject.SetActive(false);
        }
        else
        {
            TRANSFORM_NOT_LOGIN.gameObject.SetActive(false);
            TRANSFORM_LOGIN.gameObject.SetActive(true);

            
            UserInfo USERINFO = UserInformation.USERSAVEINFO.GetUserInfobyIndex(UserInformation.CURRENT_USER_ID.Get());
            if (USERINFO != null)
            {
                TEXT_USER.text = "Welcome\n" + USERINFO.USER.STR + "\n("+ USERINFO.ID.Get().ToString() + ")";
               // Debug.Log("AAAAAAAAAAkjklj");
            }
            //else Debug.Log("AAAAAAAAAA");
        }
    }

    void Update()
    {

    }
    public void OnClickSignIn()
    {
        TW.AddABoard("TWSignIn");
    }
    public void OnClickSignUp()
    {
        TW.AddABoard("TWSignUp");
    }
    public void OnClickSigOut()
    {
        TRANSFORM_NOT_LOGIN.gameObject.SetActive(true);
        TRANSFORM_LOGIN.gameObject.SetActive(false);
        UserInformation.CURRENT_USER_ID.SetAndSave(-1); 
    }
}
