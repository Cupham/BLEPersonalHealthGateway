using UnityEngine;
using System.Collections;
 
public class TI 
{ 
    public static string LANG = "VN";
    public static SuperArrayInt FOOD_AMOUNT = new SuperArrayInt(5, 0, "zv");
	//public static SuperString NAME = new SuperString("noname","tsjuhgddfmn");
	public static SuperInt COLOR = new SuperInt(0,"hfsdklfjg");
	public static SuperInt COLOR_DAY = new SuperInt(0,"sdfhfsnbdklfjg");
	public static SuperInt SERVER_DAY = new SuperInt(0,"sdfghl");
	public static SuperInt CLIENT_DAY = new SuperInt(0,"sdfglhgfd");
	public static SuperInt DA_NAP_CARD = new SuperInt(0,"sdfglddfddfhgfd");
	public static SuperInt EXP = new SuperInt(100,"toan2f3");
	public static SuperInt BOSS = new SuperInt(0,"toan2334");
	public static string TDEVICE_ID_UNIQUE = SystemInfo.deviceUniqueIdentifier+"dsd";
	
	//public static string BundleID = "annamgame.lienminhanhhungs";
    public static string LINK_RATE = "http://stgame.vn/view.php?id=66";
    public static string LINK_RATE_EN = "http://stgame.vn/view.php?id=66";
	public static int VERSION=2;
    public static MonoBehaviour MONO;
	public static void CheckInfo(string S,MonoBehaviour mono)
	{
        
	}
	void Update()
	{
		 
	}
    static void UpdateVersion() 
	{ 
		//Debug.Log ("update here"); 
        TI.ClickRate(); 
	}
	public static void LoadGame()
	{
//        Debug.Log(TI.NAME.STR);
		
         
	}
	
	public static void ClickRate()
	{
#if UNITY_ANDROID
     Application.OpenURL ("market://details?id=" + Application.identifier); 
#else
        Application.OpenURL("http://stgame.vn/php/click.php?id=127");  
#endif

        //if(LANG == "EN")
        //    Application.OpenURL(LINK_RATE_EN);
        //else Application.OpenURL(LINK_RATE);
        //return;

        //#if UNITY_ANDROID
        //TH.GetHTML(TH.MEGA_LINK+ "link_rate_and.txt",(TH.hamyes)loadurl_done,m);
        //#elif UNITY_IOS
        //TH.GetHTML(TH.MEGA_LINK+"link_rate_ios.txt",(TH.hamyes)loadurl_done,m);
        //#elif UNITY_WP8
        //TH.GetHTML(TH.MEGA_LINK+"link_rate_w8.txt",(TH.hamyes)loadurl_done,m);
        //#endif
    }
    static void loadurl_done()
	{
		if(TH.STR==null)
			ClickFace();
		else 
			Application.OpenURL(TH.STR);
	}
	public static void ClickBigkool(MonoBehaviour m)
	{
        //Debug.Log("asdsad2222222222222222222222222222222222222222222222222222222");
        //string content="http://facebook.com/stgamevn";
        //#if UNITY_ANDROID
        //TH.GetHTML("http://clipsquangcao.com/baucua/baucua_ads.php",(TH.hamyes)onbigkool,m);
        //#elif UNITY_IOS
        //TH.GetHTML("http://clipsquangcao.com/baucua/baucua_ads_ios.php",(TH.hamyes)onbigkool,m);
        //#elif UNITY_WP8
        //TH.GetHTML("http://clipsquangcao.com/baucua/baucua_ads_w8.php", (TH.hamyes)onbigkool, m);
        //#endif

        Application.OpenURL("http://stgame.vn/view.php?id=16");		
	}
	static void onbigkool()
	{
		string content = TH.STR;
		if(string.IsNullOrEmpty(content) )
			ClickFace();
		else
			Application.OpenURL (content);
		Debug.Log ("linkn bigkill="+content);
	}
	public static void ClickFace()
	{
//        #if UNITY_IOS
//        Application.OpenURL ("http://www.facebook.com/STGameVN");
//        #elif UNITY_WP8
//        Application.OpenURL ("http://www.facebook.com/STGameVN");
//        #elif UNITY_ANDROID
//            Application.OpenURL ("fb://page/128255164026922");
            
//#else
        
//#endif

        Application.OpenURL("fb://page/128255164026922"); 
        Application.OpenURL("http://www.facebook.com/STGameVN");
    }

    public static void ClickSTGAME()
	{
        Application.OpenURL("http://stgame.vn"); 
        return;

        //string content="http://facebook.com/stgamevn";
        //#if UNITY_ANDROID
        //content = "market://search?q=stgame&c=apps&hl=en";
        //#elif UNITY_IOS
        //content="http://facebook.com/stgamevn";
        //#elif UNITY_WP8
        //content ="http://www.windowsphone.com/en-US/store/publishers?publisherId=STGAME&appId=58e9d45f-0e40-43d2-bd85-d8b316702fa6";
        //#endif
        //Application.OpenURL (content);
	}
    public static void ClickSTGAMEVN()
    {
        Debug.Log(11);
        Application.OpenURL("http://stgame.vn");
    }
    public static void ClickExit()
    {
        Debug.Log("asdasd");
        TW.I.AddWarningYN("Exit?", "Do you want to Exit?");

        
    }
    static void exit()
    {
        Debug.Log("real exit");
        Application.Quit();
    }
    public static void ClickKhoeFaceBook(MonoBehaviour mono)
    {
        //TF.ToanProcess(mono);
        mono.StartCoroutine(TakeScreenshot());
    }
    static private IEnumerator TakeScreenshot()
    {
        yield return new WaitForEndOfFrame();

        var width = Screen.width;
        var height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();       //byte[] screenshot = tex.EncodeToJPG();

        //var wwwForm = new WWWForm();
        //wwwForm.AddBinaryData("image", screenshot, "3QThuThanh.png");
        //Share
        //UM_ShareUtility.FacebookShare(string.Format("Bể Cá Của Mình Đây Nhé , \r\n\r\n\r\n Cùng chơi Bể Cá Thần Kì với mình tại đây: {0}", TI.LINK_RATE), tex);
    }
    public static float time_ads = -60;
    public static void TryToShowAdmobFull()
    {
        //if (Time.time - time_ads > 120)
        //{
        //    time_ads = Time.time;
        //    if (UM_AdManager.instance.IsInited == false)
        //        UM_AdManager.instance.Init();
        //    UM_AdManager.instance.StartInterstitialAd();
        //}
    }
    static SuperInt num_open;
//    public void OnNotEnoughGem()
//    {
//#if UNITY_IOS
//        if (num_open == null)
//        {
//            num_open = new SuperInt(0, "dfkljdfjkldfkll");
//            num_open.PlusAndSave(1);
//        }

//        if (num_open.Get() > 3)
//            TW.I.AddWarningYN("", "Not Engough Gems, Do you want to get more free GEMS", OnClickFreeGem);
//        else TW.I.AddWarning("", "Not Engough Gems");    
//#else
//        TW.I.AddWarningYN("", "Not Engough Gems, Do you want to get more free GEMS", OnClickFreeGem);
//#endif
//    }
//    public void OnClickFreeGem()
//    {
//        TW.I.AddFreeGem();
//    }


   
    static public void TryToShowVideoAds()
    {
        //TW.I.AddWarning("", "TryToShowVideoAds()");
        //tadcolony.I.OnClick();
    }
    static  public void TryTobuyGem()
    {
        TW.I.AddWarning("", "Sorry, the shop is not available on this version!");
    }
}
