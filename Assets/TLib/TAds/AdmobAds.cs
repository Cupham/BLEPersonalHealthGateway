//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using GoogleMobileAds.Api;

//public class AdmobAds : MonoBehaviour
//{
//    static public AdmobAds I;
//    public static bool is_active = false;
//    public static bool is_loaded_banner = false;
//    void Awake()
//    {
//        if (I != null)
//        {
//            Destroy(gameObject);
//            return;
//        }
//        DontDestroyOnLoad(gameObject);
//        I = this;
//    }
//    void Start ()
//    {
//        if (is_active)
//        {
//            RequestBanner();
//            StartCoroutine(autoshowinterestial());  
//        }
//    }
//    IEnumerator autoshowinterestial()
//    {
//        yield return new WaitForSeconds(60);
//        while (true)
//        {
//            LoadInterstitial();
//            yield return new WaitForSeconds(120);

//        }
//    }
//    void Update ()
//    {
		 
//	}

//    public  void RequestBanner()
//    {
//        Debug.Log("TOANSTT: Requesting admob banner");
//        if (is_loaded_banner) return;
//        is_loaded_banner = true;
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//        string adUnitId = "ca-app-pub-2122306229547761/4349606738";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-2122306229547761/8779806335";
//#else
//        string adUnitId = "unexpected_platform";
//#endif
//         bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
//        bannerView.OnAdLoaded += BannerView_OnAdLoaded;
//        bannerView.OnAdFailedToLoad += BannerView_OnAdFailedToLoad;
//        AdRequest request = new AdRequest.Builder().Build();
//        bannerView.LoadAd(request); 
//    }
//    BannerView bannerView;
//    private void BannerView_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
//    {
//        Debug.Log("TOANSTT:  admob BannerView_OnAdFailedToLoad: " + e.Message);
//        //throw new System.NotImplementedException();
//    }

//    private void BannerView_OnAdLoaded(object sender, System.EventArgs e)
//    {
//        Debug.Log("TOANSTT:  admob BannerView_OnAdLoaded: ");
//        //throw new System.NotImplementedException(); 
//        bannerView.Show(); 
//    }

//    InterstitialAd interstitial;
//    public void LoadInterstitial()
//    {
//        Debug.Log("TOANSTT: Requesting admob LoadInterstitial");
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-2122306229547761/5826339932";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-2122306229547761/1256539539";
//#else
//        string adUnitId = "unexpected_platform";
//#endif
//        interstitial = new InterstitialAd(adUnitId);
//        AdRequest request = new AdRequest.Builder().Build();
//        interstitial.LoadAd(request);
//        interstitial.OnAdLoaded += Interstitial_OnAdLoaded;
//        interstitial.OnAdFailedToLoad += Interstitial_OnAdFailedToLoad;
//    }

//    private void Interstitial_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
//    {
//        Debug.Log("TOANSTT: Interstitial_OnAdFailedToLoad : " + e.Message);
//        //throw new System.NotImplementedException();
//    }

//    private void Interstitial_OnAdLoaded(object sender, System.EventArgs e)
//    {
//        if (interstitial.IsLoaded())
//        {
//            Debug.Log("TOANSTT: Interstitial_OnAdLoaded");
//            interstitial.Show();
//        }
//        else
//        {

//            Debug.Log("TOANSTT: Interstitial_OnAdLoaded but fail");
//        }
//    }
    
//}
