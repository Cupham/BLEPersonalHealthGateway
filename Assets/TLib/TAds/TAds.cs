using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
////tads ver 1.4
public class TAds : MonoBehaviour
{
    public Image SPRITE;
    public Text LABEL; 

    public string LINK = "https://stgame.vn";
    string TEXT = "STGAME.VN";
    static public string SUPER_LINK = "http://clipsquangcao.com/ads/";
    public bool IS_IMAGE_ADS = false;
    static List<AAds> LIST_ADS;
    public int CURENT_ADS = 0;
    public ADS_TYPE TYPE;
    //public bool IS_GLOBAL = false;
    public SuperString SAVED_CONTENT;
    public SuperInt LOAD_COUNT;
    void Start()
    {
        SAVED_CONTENT = new SuperString("http://stgame.vn|Pikachu 2016|ads_pika2016.png", "tads534");
        LOAD_COUNT = new SuperInt(0, "tadsloadcount");

        if (LOAD_COUNT.Get() == 0)
        {
            Debug.Log("loading new ads");
            GetADS();

        }
        else
        {
            Debug.Log("no: load saved ads");

            LOAD_COUNT.PlusAndSave(1);
            if (LOAD_COUNT.Get() >= 5) LOAD_COUNT.SetAndSave(0);
            ParseCONTENT(SAVED_CONTENT.STR,true);
        }
        
    }


    public void GetADS()
    {
        IS_IMAGE_ADS = false;


        string link = SUPER_LINK + "TADS.php?V=1&GR=0";
        if (TYPE == ADS_TYPE.STGAME_ENGLISH) link = SUPER_LINK + "TADS.php?V=1&GR=1";
        else if (TYPE == ADS_TYPE.VAD) link = SUPER_LINK + "TADS.php?V=1&GR=0";
        if (LIST_ADS == null)
        {
            GetHTML(link, (TAds.hamyes)OnLoadDone, this);
        }
        else
        {
            ReUseAds();
        }

    }
    void OnLoadDone()
    {
            string STR = STR_LOAD;
            Debug.Log(STR);
            if (STR == null || STR.Length < 5) { ParseCONTENT(SAVED_CONTENT.STR,true); return; }
            STR = STR.Trim();
            STR = STR.Replace("\r\n","");
            STR = STR.Replace("\r", "");
            STR = STR.Replace("\n", "");

            //Debug.Log(STR);

            string[] ttt = STR.Split('$');
            if (ttt.Length > 1)
                STR = ttt[1];
            else STR = ttt[0];
            //return;
            string[] STRA = STR.Split('|');

            int NUM = STRA.Length / 3;

            if (NUM >= 3)
            { 
                SAVED_CONTENT.STR = STR;
                SAVED_CONTENT.Save(); 
                LOAD_COUNT.PlusAndSave(1);
                ParseCONTENT(STR,false);
            }
            else
            { 
                STR = SAVED_CONTENT.STR;
                ParseCONTENT(STR, true);
            }
            
            
        }
    public void ParseCONTENT(string STR,bool is_saved)
        {
            int index;
            string[]  STRA = STR.Split('|');
            int NUM = STRA.Length / 3;
            LIST_ADS = new List<AAds>();
            try
            {
                for (int i = 0; i < NUM; i++)
                {
                    index = i * 3;
                    string link = STRA[index];
                    while (link.Length > 3 && link[0] != 'h')
                    {
                        link.Remove(0, 1);
                    }
                    if (SPRITE == null) SPRITE = GetComponent<Image>();
                    if (SPRITE == null) Debug.Log(1);
                    LIST_ADS.Add(new AAds(STRA[index + 1], link, STRA[index + 2], SPRITE, LABEL, this, this));
                    //   Debug.Log(link);
                }
                CURENT_ADS = Random.Range(0, LIST_ADS.Count);
               // if (!is_saved)
                LIST_ADS[CURENT_ADS].LoadImage(this, this, LABEL, SPRITE, is_saved);

            }
            catch (UnityException e)
            {
                Debug.Log("Tads exceptoion: contet =" + STR_LOAD);
            }
        }
        public void LoadRealAds()
        {
            try
            {
                CURENT_ADS = Random.Range(0, LIST_ADS.Count);
                LIST_ADS[CURENT_ADS].LoadImage(this, this, LABEL, SPRITE,true);
            }
            catch (UnityException e)
            {
                Debug.Log("Tads exceptoion: contet =" + STR_LOAD);
            }
        }
        public void ReUseAds() 
        {
            CURENT_ADS = Random.Range(0, LIST_ADS.Count);
            LIST_ADS[CURENT_ADS].ReUseImage(this, this, LABEL, SPRITE);
        }
        public delegate void hamyes();
        public delegate void hamno();
        public static hamyes onhamyes;
        public static hamno onhamno;
        public static string STR_LOAD;
        static public void GetHTML(string uri, hamyes c, MonoBehaviour mono)
        {
            onhamyes = yes;
            onhamno = no;
            onhamyes += c;
            mono.StartCoroutine(MyLoadPage_1(uri, onhamyes));
        }
        static IEnumerator MyLoadPage_1(string url, hamyes c)
        {
            WWW www = new WWW(url);
            yield return www;
            if (www.error == null)
            {
                STR_LOAD = www.text;
                c();
            }
            else
            {
                STR_LOAD = null;
                c();
            }
        }
        static void yes() { }
        static void no() { }
        public void OnClick()
        {
            Application.OpenURL(LINK);
        }
    }

    public class AAds
    {
        public string TEXT = "STGAME";
        public string LINK = "https://stgame.vn";
        public string LINK_IMAGE = null;
        public Image SPRITE;
        public Text LABEL;
        MonoBehaviour M;
        TAds TADS;
        public AAds(string text, string link, string link_image, Image sprite, Text label, MonoBehaviour m, TAds tads)
        {
            TADS = tads;
            M = m;
            TEXT = text;
            LINK = link;
            LINK_IMAGE = link_image;
            SPRITE = sprite;
            LABEL = label;
        }
        public Sprite SPRITEMP = null;
        public void LoadImage(MonoBehaviour m, TAds tads, Text label, Image sprite, bool is_saved)
        {
            LABEL = label;
            M = m;
            TADS = tads;
            //Debug.Log(LINK_IMAGE);
            if (!is_saved)
                M.StartCoroutine(LoadImage(TAds.SUPER_LINK + LINK_IMAGE));
            else LABEL.text = TEXT;
            TADS.LINK = LINK;

        }
        public void ReUseImage(MonoBehaviour m, TAds tads, Text label, Image sprite)
        {
            SPRITE = sprite;
            LABEL = label;
            M = m;
            TADS = tads;
            TADS.LINK = LINK;
            if (SPRITEMP == null)
            {
                LABEL.text = TEXT;
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    SPRITE.sprite = SPRITEMP;
                    LABEL.text = "";
                }
                else
                {
                    LABEL.text = TEXT;
                }
            }
        }

        public IEnumerator LoadImage(string imageUrl)
        {
            Debug.Log(123);
            WWW loader = new WWW(imageUrl);
            yield return loader;
            if (loader.error == null)
            {
                int w = loader.texture.width;
                int h = loader.texture.height;
                SPRITEMP = Sprite.Create(loader.texture, new Rect(0, 0, w, h), new Vector2(0.5f, 0.5f), 1);
                //if (SPRITE == null) Debug.Log(1);
                //if (SPRITE.sprite == null) Debug.Log(1);
                //if (SPRITEMP == null) Debug.Log(1);
                
                SPRITE.sprite = SPRITEMP;
                //TADS.GetComponent<UIButton>().normalsprite = SPRITEMP;
                LABEL.text = "";
            }
            else
            {
                SPRITEMP = null;
                LABEL.text = TEXT;
            }


        }
       
    }

 public enum ADS_TYPE
        {
            STGAME_NORMAL, STGAME_ENGLISH,VAD
        }