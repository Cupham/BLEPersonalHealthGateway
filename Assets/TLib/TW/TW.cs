using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TW : MonoBehaviour 
{
    public static TW instace_;
    public Dictionary<string, Object> PREFAPS;
    public List<GameObject> LISTPOPIP = new List<GameObject>();
    public static float SCALE = 1f; 
    public static bool IS_WARNING
    {
        get
        {
            //if (I.LISTPOPIP.Count == 0) return false;
            //return true;
            return I.LISTPOPIP.Count != 0;
        }
    }
    public static void RemoveMe(GameObject g)
    {
        I.LISTPOPIP.Remove(g);
    }
    public static void AddMe(GameObject g)
    {
        I.LISTPOPIP.Add(g);
    }
    public static TW I
    {
        get
        {
            if(instace_ == null)
            {
                TW h = FindObjectOfType<TW>();
                if (h != null) return h;
                GameObject g = Instantiate(Resources.Load("TW/canvas")) as GameObject;
                g.transform.localScale = Vector3.one*0.03333333333f;
                return g.GetComponent<TW>();
            }
            return instace_;
        }
    }
    void Awake()
    {
       
        if (PREFAPS != null)
        {
            PREFAPS.Clear();
        }
        PREFAPS = new Dictionary<string, Object>();
        LISTPOPIP = new List<GameObject>();
    }
    void Start () 
    {
	
	}
	void Update () 
    {
	
	}
    void OnLevelWasLoaded(int level)
    {
        instace_ = null;
    }
    public TWWarning AddWarning(string title, string content, TWBoard.yes ondone = null)
    {
        GameObject g = AddPbjectWarning(Getprefap("Warning"));
        TWWarning t = g.GetComponent<TWWarning>();
        Settext(t, title, content);
        t.AddYes(ondone);
        return t;
    }
    public TWWarningYN AddWarningYN(string title, string content, TWBoard.yes onyes = null, TWBoard.no onno = null)
    {
        GameObject g = AddPbjectWarning(Getprefap("WarningYN"));
        TWWarningYN t = g.GetComponent<TWWarningYN>();
        Settext(t, title, content);
        t.AddYes(onyes);
        t.AddNo(onno);
        return t;
    }
    public TWWarningInput AddWarningInput(string title, string content, TWBoard.yes onyes = null, TWBoard.no onno = null)
    {
        GameObject g = AddPbjectWarning(Getprefap("WarningInput"));
        TWWarningInput t = g.GetComponent<TWWarningInput>();
        Settext(t, title, content);
        t.AddYes(onyes);
        t.AddNo(onno);
        return t;
    }
   
   

    public Object Getprefap(string s)
    {
        if (!PREFAPS.ContainsKey(s)) 
        {
            Object o = Resources.Load("TW/" + s);
            if (o == null) Debug.LogError("khong ton tai prefap:" + "TW/" + s);
            PREFAPS.Add(s, o);
        }
        return PREFAPS[s];
    }
    public GameObject AddPbjectWarning(Object o)
    {
        GameObject g = Instantiate(o) as GameObject;
        g.transform.SetParent(this.transform,false);
        g.transform.localScale = Vector3.one;
        g.transform.localPosition = Vector3.zero;
        //TWBoard t1 = g.GetComponent<TWBoard>();
        //if (t1 != null) { t1.BODY.GetComponent<Image>().rectTransform.localScale = Vector3.one * SCALE; Debug.Log(Vector3.one * SCALE); }
        //else Debug.Log("aaaaaaaaaaaaaa");
        RectTransform t = g.GetComponent<RectTransform>();
       // t.anchoredPosition = new Vector2(0, 0);
        //Debug.Log(t.anchoredPosition);
       // t.anchoredPosition3D = new Vector3(0, 0, 0);
        t.sizeDelta = new Vector2(0, 0);
        
        AddMe(g);
        return g;
    }
    public void Settext(TWBoard t, string titile, string content)
    {
        t.Settext(titile, content);
    }


    public static GameObject AddLoading(TWBoard.yes onyes = null,int timeout = 0)
    {
        GameObject g = I.AddPbjectWarning(I.Getprefap("Loading"));
        
        g.transform.localScale = Vector3.one;
        if (timeout > 0)
        {
            I.StartCoroutine(autorevwlading(timeout));
        }
        TWLoading t = g.GetComponent<TWLoading>();
        t.AddYes(onyes);
        t.d_time = 1.0f / timeout;
        return g;
    }
    static IEnumerator autorevwlading(int time)
    {
        yield return new WaitForSeconds(time);
        RemoveLoading();
    }
    public static void RemoveLoading()
    {
        TWLoading t = FindObjectOfType<TWLoading>();
        if (t != null)
        {
            t.DeleteMe();
        }
    }
    public static GameObject AddABoard(string name)
    {
        GameObject g = I.AddPbjectWarning(I.Getprefap(name));
        AddMe(g);
        return g;
    }




}
