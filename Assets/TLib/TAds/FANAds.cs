//using UnityEngine;
//using System.Collections;
//using AudienceNetwork;

//public class FANAds : MonoBehaviour
//{
//    private AdView adView;
//    static public FANAds I;
//    void Awake() 
//    {


//        AdSettings.AddTestDevice("182ee9da99f32c0d3b3b45004da8dc37");
//        Debug.Log(123);

//        if (I != null)
//        {
//            Destroy(gameObject);
//            return;
//        }
//        DontDestroyOnLoad(gameObject);
//        I = this;
//        AdView adView = new AdView("201459860324734_201460666991320", AdSize.BANNER_HEIGHT_50); 
//        this.adView = adView;
//        this.adView.Register(this.gameObject);
//        this.adView.AdViewDidLoad = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN: Ad view loaded.");
//            this.adView.Show(0);   
//        });
//        adView.AdViewDidFailWithError = (delegate (string error)
//        {
//            Debug.Log("TOANSTT FAN:Ad view failed to load with error: " + error);

//            if (AdmobAds.I != null && !AdmobAds.is_active)
//            {
//                Debug.Log("TOANSTT FAN: trying to load admob banner from FAN: " + error); 
//                AdmobAds.I.RequestBanner();
//            }
//        });
//        adView.AdViewWillLogImpression = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN:Ad view logged impression."); 
//        });
//        adView.AdViewDidClick = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN:Ad view clicked.");
//        });

//        adView.LoadAd();


//        //StartCoroutine(autoshowinterestial()); 
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
//    private InterstitialAd interstitialAd;
//    private bool isLoaded;

//    // UI elements in scene
//    //public Text statusLabel;

//    // Load button
//    public void LoadInterstitial()
//    {
//        InterstitialAd interstitialAd = new InterstitialAd("201459860324734_201461113657942"); 
//        this.interstitialAd = interstitialAd;
//        this.interstitialAd.Register(this.gameObject);

//        this.interstitialAd.InterstitialAdDidLoad = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN: Interstitial ad loaded.");
//            this.isLoaded = true;

//            this.interstitialAd.Show();
//            this.isLoaded = false;

//        });
//        interstitialAd.InterstitialAdDidFailWithError = (delegate (string error)
//        {
//            Debug.Log("TOANSTT FAN: Interstitial ad failed to load with error: " + error);

//            if(AdmobAds.I!=null && !AdmobAds.is_active)
//            {
//                Debug.Log("TOANSTT FAN: trying to load admob interestial from FAN: " + error);
//                AdmobAds.I.LoadInterstitial();
//            }

//        });
//        interstitialAd.InterstitialAdWillLogImpression = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN: Interstitial ad logged impression.");
//        });
//        interstitialAd.InterstitialAdDidClick = (delegate ()
//        {
//            Debug.Log("TOANSTT FAN: Interstitial ad clicked.");
//        });

//        this.interstitialAd.LoadAd();
//    }

//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
