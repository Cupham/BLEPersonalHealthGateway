//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
////using StartApp;

//public class TAdMobBanner : MonoBehaviour
//{


//    public GADBannerSize size = GADBannerSize.SMART_BANNER;
//    static public GADBannerSize size_s = GADBannerSize.SMART_BANNER;
//    public TextAnchor anchor = TextAnchor.UpperCenter;
//    static public TextAnchor anchor_s = TextAnchor.UpperCenter;
//    public static bool is_have_pubcenter = true;
//    public static bool is_recive_from_pubcenter = false;

//#if UNITY_ANDROID &&a
//        public StartAppWrapper.BannerPosition startapp_anchor = StartAppWrapper.BannerPosition.TOP;
//#endif

//    static public TAdMobBanner I;

//    public Text text;
//    void Awake()
//    {
//        I = this;
//        anchor_s = anchor;
//        size_s = size;
//    }
//    void Start()
//    {
//        StartCoroutine(start_delay());
//    }
//    IEnumerator start_delay()
//    {
//#if UNITY_ANDROID  && a
//        StartAppWrapper.init();
//#endif
//        yield return new WaitForSeconds(0.05f);
//        if (!GoogleMobileAd.IsInited)
//        {
//            GoogleMobileAd.Init();
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, ON_INTERSTITIAL_AD_FAILED_LOADING);
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, ON_INTERSTITIAL_AD_LOADED);
//        }
//        yield return new WaitForSeconds(0.05f);

//#if !UNITY_WP8
//            ShowBanner();
//#else
//        if (is_recive_from_pubcenter)
//        {
//            if (is_have_pubcenter == false)
//                ShowBanner();
//        }
//        else ShowBanner();
//#endif


//        yield return new WaitForSeconds(30);
//        TryToShow_AdmobInterstitialAd(15);
//    }
//    public static void ShowBannerWPFromNavtive()
//    {
//        is_recive_from_pubcenter = true;
//        is_have_pubcenter = false;
//    }
//    public static void DontShowBannerWPFromNavtive()
//    {
//        is_recive_from_pubcenter = true;
//        is_have_pubcenter = true;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            Application.LoadLevel("t2");
//        }
//    }
//    public static float last_time_ads = -45;
//    static public void TryToShow_AdmobInterstitialAd(float time = 60)
//    {
//        //if (TAdMobBanner.I == null) return;
//        if (TAdMobBanner.I.text != null) TAdMobBanner.I.text.text += "ADMOB try to show full screen\n";
//        if (!GoogleMobileAd.IsInited)
//        {
//            GoogleMobileAd.Init();
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, TAdMobBanner.I.ON_INTERSTITIAL_AD_FAILED_LOADING);
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, TAdMobBanner.I.ON_INTERSTITIAL_AD_LOADED);
//        }

//        if (Time.time - last_time_ads > time)
//        {
//            last_time_ads = Time.time;
//            Debug.Log("TAdmob: trying to show full ads");
//            GoogleMobileAd.StartInterstitialAd();
//        }
//    }

//    public void OnLabelCLick()
//    {
//        ShowStartAppBanner();
//        ShowStartAppInteresital();

//    }
//    public void quit()
//    {
//        Application.Quit();
//    }

//    public void ShowStartAppBanner()
//    {
//#if UNITY_ANDROID && a
//        if (text != null) text.text += "STARTAPP try to show banner \n";
//                StartAppWrapper.addBanner(
//                      StartAppWrapper.BannerType.AUTOMATIC,
//                      startapp_anchor); 
//#endif
//    }

//    public void ShowStartAppInteresital()
//    {
//#if UNITY_ANDROID && a

//        if (text != null) text.text += "STARTAPP try to show interestial \n";
//        StartAppWrapper.loadAd(startappevent); 
//#endif
//    }

//    private void ON_BANNER_AD_OPENED()
//    {
//        if (text != null) text.text += "ON_BANNER_AD_OPENED\n";
//    }
//    private void ON_AD_IN_APP_REQUEST()
//    {
//        if (text != null) text.text += "ON_AD_IN_APP_REQUEST\n";
//    }
//    private void ON_BANNER_AD_FAILED_LOADING()
//    {
//        if (text != null) text.text += "ON_BANNER_AD_FAILED_LOADING\n";

//        Debug.Log("ON_BANNER_AD_FAILED_LOADING");
//        ShowStartAppBanner();
//    }
//    private void ON_BANNER_AD_LOADED()
//    {
//        if (text != null) text.text += "ON_BANNER_AD_LOADED\n";
//    }
//    private void ON_INTERSTITIAL_AD_FAILED_LOADING()
//    {
//        if (text != null) text.text += "ON_INTERSTITIAL_AD_FAILED_LOADING\n";
//        Debug.Log("ON_INTERSTITIAL_AD_FAILED_LOADING");
//        ShowStartAppInteresital();
//    }
//    private void ON_INTERSTITIAL_AD_LOADED()
//    {
//        if (text != null) text.text += "ON_INTERSTITIAL_AD_LOADED\n";
//    }




//    public void ShowBanner()
//    {
////#if UNITY_WP8
////#else
////        if ( PlayerInfo.NUM_OPEN_GAME.Get() <= 3) return; 
////#endif


//        if (TAdMobBanner.I.text != null) TAdMobBanner.I.text.text += "ADMOB try to show banner\n";
//        if (!GoogleMobileAd.IsInited)
//        {
//            GoogleMobileAd.Init();
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_FAILED_LOADING, ON_INTERSTITIAL_AD_FAILED_LOADING);
//            GoogleMobileAd.addEventListener(GoogleMobileAdEvents.ON_INTERSTITIAL_AD_LOADED, ON_INTERSTITIAL_AD_LOADED);
//        }

//        GoogleMobileAdBanner banner;
//        banner = GoogleMobileAd.CreateAdBanner(anchor, size);

//        banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_FAILED_LOADING, ON_BANNER_AD_FAILED_LOADING);
//        banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_LOADED, ON_BANNER_AD_LOADED);
//        banner.addEventListener(GoogleMobileAdEvents.ON_BANNER_AD_OPENED, ON_BANNER_AD_OPENED);
//        banner.addEventListener(GoogleMobileAdEvents.ON_AD_IN_APP_REQUEST, ON_AD_IN_APP_REQUEST);

//        if (banner.IsLoaded && !banner.IsOnScreen)
//        {
            
//            banner.Show();
//        }
//        Debug.Log("TAdmob: trying to show banner ads");
//    }
//    static public IEnumerator ShowBanner2()
//    {
//        yield return new WaitForSeconds(10);
//        if (!GoogleMobileAd.IsInited)
//        {
//            GoogleMobileAd.Init();
//        }

//        GoogleMobileAdBanner banner;
//        banner = GoogleMobileAd.CreateAdBanner(anchor_s, size_s);
//        if (banner.IsLoaded && !banner.IsOnScreen)
//        {
//            banner.Show();
//        }
//    }




//    public string sceneBannerId
//    {
//        get
//        {
//            return Application.loadedLevelName + "_" + this.gameObject.name;
//        }
//    }

//#if UNITY_ANDROID && a
//    class Startappevent :  StartAppWrapper.AdEventListener
//    {
//        public void onReceiveAd()
//        {
//            if (TAdMobBanner.I.text != null) TAdMobBanner.I.text.text += "STARTAPP onReceiveAd\n";
//            StartAppWrapper.showAd();
//        }
//        public void onFailedToReceiveAd()
//        {
//            if (TAdMobBanner.I.text != null)  TAdMobBanner.I.text.text += "STARTAPP onFailedToReceiveAd\n";

//        }
//    }
//    static Startappevent startappevent = new Startappevent(); 
//#endif
//}
