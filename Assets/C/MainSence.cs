using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSence : MonoBehaviour
{
    public static MainSence I;
    
    public GameObject TAB_USER;
    public GameObject TAB_DEVICE;
    public GameObject TAB_CHECK;
    void Awake()
    {
        I = this;
        
    }
    void Start()
    {
       // Debug.Log("A123");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCLickUser()
    {
        TAB_USER.gameObject.SetActive(true);
        TAB_DEVICE.gameObject.SetActive(false);
        TAB_CHECK.gameObject.SetActive(false);
    }
    public void OnCLickDevice()
    {
        if(UserInformation.CURRENT_USER_ID.Get()<0)
        {
            TW.I.AddWarning("", "Please Log in!");
            return;
        }

        TAB_USER.gameObject.SetActive(false);
        TAB_DEVICE.gameObject.SetActive(true);
        TAB_CHECK.gameObject.SetActive(false);
    }
    public void OnCLickCheck()
    {
        if (UserInformation.CURRENT_USER_ID.Get() < 0)
        {
            TW.I.AddWarning("", "Please Log in!");
            return;
        }
        TAB_USER.gameObject.SetActive(false);
        TAB_DEVICE.gameObject.SetActive(false);
        TAB_CHECK.gameObject.SetActive(true);
    }
}
