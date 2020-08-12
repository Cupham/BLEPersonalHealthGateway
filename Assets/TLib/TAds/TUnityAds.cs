//using System.Collections;
//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Advertisements;

//public class TUnityAds : MonoBehaviour
//{
//     Start is called before the first frame update
//    void Start()
//    {
        
//    }

//     Update is called once per frame
//    void Update()
//    {
        
//    }
//    static float last_time = -60;
//    public static void TrytoShowFullAds(float time)
//    {
//        if (UserInfo.IS_REMOVE_ADS.Get() == 1) return;
//        if(Time.time - last_time > time)
//        {
//            Debug.Log("aaa123");
//            if (Advertisement.IsReady())
//            {
//                Advertisement.Show();
//                last_time = Time.time;
//            }
//            else Debug.Log("no need");
//        }
//    }

//    static Action action_ok;
//    static Action onskip;
//    static Action onfail;
//    static private void HandleShowResult(ShowResult result)
//    {
//        switch (result)
//        {
//            case ShowResult.Finished:
//                Debug.Log("The ad was successfully shown.");
                
//                if(action_ok!=null) action_ok();
//                break;
//            case ShowResult.Skipped:
//                VUIManager.Instance.OpenPopup<VPopupWarning>("The ad was skipped before reaching the end.");
//                Debug.Log("The ad was skipped before reaching the end.");
//                if (onskip != null) onskip();
//                break;
//            case ShowResult.Failed:
//                Debug.LogError("The ad failed to be shown.");
//                VUIManager.Instance.OpenPopup<VPopupWarning>("The ad failed to be shown.");
//                if (onfail != null) onfail();
//                break;
//        }
//    }

//    static public void ShowRewardedAd(Action onok=null, Action onfail_=null, Action onskip_=null)
//    {
//        action_ok = onok;
//        onfail = onfail_;
//        onskip = onskip_;
//        Debug.Log("Trying to show reward ads");
//        if (Advertisement.IsReady("rewardedVideo"))
//        {
//            var options = new ShowOptions { resultCallback = HandleShowResult };
//            Advertisement.Show("rewardedVideo", options);
//        }
//    }
//}
