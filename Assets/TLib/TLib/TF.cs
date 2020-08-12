//using UnityEngine;
//using System.Collections;
//#if !UNITY_WP8
//using Facebook;
//#endif
//public class TF
//{
//    //static public UITexture screenShotTexture;
//    public static MonoBehaviour mono;
//    public static bool is_login = false;
//    public static string MESS0 = "Bể Cá Của Mình Nè!";
//    public static string MESS1 = "\r\n Tải Bể Cá Thần Kì Tại http://stgame.vn";
//    static public void Init(MonoBehaviour mono_)
//    {
//        mono = mono_;
//        //screenShotTexture = new UITexture();

//    }
//    static public void ToanProcess(MonoBehaviour mono_)
//    {
//        Init(mono_);
//        Start();
//    }
//    static public void ToanProcessPopup(MonoBehaviour mono_)
//    {
//        Init(mono_);
//        WarningINPUT w = WARNING_Manager.AddWarningINPUTLow("Khoe Bể Cá", "Nhập Nội Dung Mà Bạn Muốn Chia Sẽ Với Bạn Bẽ", MESS0);
//        w.onhamyes += Clickshareyes;
//        //Start();
//    }

//    static void Clickshareyes()
//    {
//        MESS0 = WarningINPUT.STRING;
//        WARNING_Manager.CloseAWindow();
//        Start();
//    }
//    public static void Start()
//    {

//        #if !UNITY_WP8
//        FB.Init(initFBDelegate, HideUnityDele, null);
//#endif
//    }
//    static public void shareFB()
//    {
//        #if !UNITY_WP8
//        if (!FB.IsLoggedIn)
//        {
//            FB.Login("publish_actions", callBackLogin);
//        }
//        else
//        {
//            mono.StartCoroutine(TakeScreenshot1());
//        }
//#endif
//    }
//    #if !UNITY_WP8
//    static public void callBackLogin(FBResult result)
//    {
//        if (FB.IsLoggedIn)
//        {
//            mono.StartCoroutine(TakeScreenshot1());
//        }
//        Debug.Log("Loging call back " + result.Text);
//    }
//#endif
//    static byte[] scren = null;
//    static private IEnumerator TakeScreenshot1()
//    {
//        yield return new WaitForEndOfFrame();
//        Texture2D snap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
//        //screenShotTexture.mainTexture = snap;
//        snap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
//        snap.Apply();
//        scren = snap.EncodeToPNG();

//        mono.StartCoroutine(TakeScreenshot(MESS0 + MESS1));
//    }
//    static private IEnumerator TakeScreenshot(string message)
//    {
//        yield return new WaitForEndOfFrame();
//        var wwwForm = new WWWForm();
//        wwwForm.AddBinaryData("image", scren, "barcrawling.png");
//        wwwForm.AddField("name", message);
//         #if !UNITY_WP8
//        FB.API("me/photos", HttpMethod.POST, callBackPostPhoto, wwwForm);
//#endif
//    }

//    static public void initFBDelegate()
//    {
//        shareFB();
//    }
//    static public void HideUnityDele(bool isUnityHide)
//    {
//        if (!isUnityHide)
//        {
//            Time.timeScale = 0;
//        }
//        else
//        {
//            Time.timeScale = 1;
//        }
//    }
//#if !UNITY_WP8
//    static public void callBackPostPhoto(FBResult result)
//    {
//        Debug.Log(result.Text);
//        WARNING_Manager.CloseAWindow();
//    }
//#endif
//}
