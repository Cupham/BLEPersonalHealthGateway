//using UnityEngine;
//using System.Collections;

//public class tadcolony : MonoBehaviour
//{

//    public string appVersion = "1.0";
//    public string appId = "";
//    public string zoneId = "";
//    public static tadcolony I;
//    void Awake()
//    {
//        I = this;
//    }
//    void Start()
//    {
//        ConfigureZoneString();
//        AdColony.Configure(appVersion, appId, zoneId);
//        AdColony.OnAdAvailabilityChange = OnAdAvailabilityChange;
//        AdColony.OnV4VCResult = UpdateCurrencyText;
//    }
//    public void OnAdAvailabilityChange(bool available, string zoneIdChanged)
//    {
//        if (available && zoneId == zoneIdChanged)
//        {
//            Debug.Log("ready");
//        }
//        else
//        {
//            Debug.Log("ready no no no");
//        }
//    }
//    void Update()
//    {

//    }
//    public void UpdateCurrencyText(bool success, string currencyName, int currencyAwarded)
//    {
//        Debug.Log("OnV4VCResult WAS JUST TRIGGERED.");
//        Debug.Log("Was Successful: " + success);
//        Debug.Log("--------------------------------");

//        //TW.I.AddWarning("", "you just got a life because watch video");

//        //GameUI.I.ForceSave();
//    }
//    public void OnClick()
//    {
//        Debug.Log("OnClick");
//        if (AdColony.IsVideoAvailable(zoneId))
//        {
//            Debug.Log(this.gameObject.name + " triggered playing a video ad.");
//            AdColony.OfferV4VC(true, zoneId);
//        }
//        else
//        {
//            TW.I.AddWarning("", "Sorry the video is not availabel yet");
//            Debug.Log(this.gameObject.name + " tried to trigger playing an ad, but the video is not available yet.");
//        }
//    }
//    public void ConfigureZoneString()
//    {
//#if UNITY_ANDROID
//        // App ID
//        appId = "appf656669bda164cd7ab";
//        // Video zones
//        zoneId = "vz0dc103c5b4d8408b9c";
//        //If not android defaults to setting the zone strings for iOS
//#else
//        // App ID
//        appId = "app80225a5a941e40cc98";
//        // Video zones
//        zoneId = "vzf4da7426e3694ba3ac";
//#endif
//    }
//}
