using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
public class TWBoard : MonoBehaviour 
{
    public delegate void yes();
    public yes onyes;
    public delegate void no();
    public no onno;
    public Text title;
    public Text content;
    public GameObject BODY;
	public void InitTWBoard () 
	{
        onyes += yes_;
        onno += no_;
        Show();
	}
	void Update () 
	{
	
	}
    void yes_()
    {
    }
    void no_()
    {
    }
    public void AddNo(no hamno2)
    {
        onno += hamno2;
    }
    public void AddYes(yes hamyes2)
    {
        onyes += hamyes2;
    }
    virtual public void ClickX()
    {
        //if (!WARNING_Manager.Is_ClickRight_AndRemove(gameObject)) return;
        
        onno();
        //Sounds_UI.I.PLayOneShot(Sounds_UI.I.clickx);
        //Destroy(this.gameObject);
        DeleteMe();
    }
    virtual public void ClickYES()
    {
        onyes();
        DeleteMe();
        //Debug.Log("you are calling a virtuel");
        //Sounds_UI.I.PLayOneShot(Sounds_UI.I.click);
    }
    public void Settext(string title_, string content_)
    {
        SettextTitle(title_);
        SettextContent(content_);
    }
    public void SettextTitle(string text)
    {
        if (title != null)
            title.text = text;
    }
    public void SettextContent(string text)
    {
        if (content != null)
            content.text = text;
    }
    Image image;
    public void Show()
    {
        //Debug.Log(1);
        if (BODY != null)
        {
            BODY.transform.localScale = new Vector3(0.9f, 0.9f, 1) * TW.SCALE;
            BODY.transform.DOScale(Vector3.one, 0.1f);
            //iTween.ScaleTo(BODY.gameObject, iTween.Hash("scale", Vector3.one * TW.SCALE, "time", 0.4f, "oncomplete", "OnShow"));
            image = GetComponent<Image>();

           // iTween.ValueTo(this.gameObject, iTween.Hash("from", 0, "to", 0.39f, "onupdate", "valuetranform", "time", 0.4f*0.8f));
        }
    }
    Color c;
    public void valuetranform(float v) 
    {
        if (image != null)
        {
            c = image.color;
            c.a = v;
            image.color = c;
        }
    }
    void OnShow() 
    {
       // Debug.Log(1);
    }
    IEnumerator OnDeleteMe_func(float time)
    {
        yield return new WaitForSeconds(time);
        OnDeleteMe();
    }
    void OnDeleteMe()
    {
        TW.RemoveMe(gameObject);
        DestroyImmediate(this.gameObject);
    }
    public void DeleteMe()
    {
        if (BODY != null)
        {
            BODY.transform.DOScale(Vector3.one*0.8f, 0.1f);
            image = GetComponent<Image>();
           // iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.39f, "to", 0, "onupdate", "valuetranform", "time", 0.8f * TW.SCALE * 0.8f));
            StartCoroutine(OnDeleteMe_func(0.1f));
        }
        else
        {
            TW.RemoveMe(gameObject);
            Destroy(this.gameObject);
        }
    }
}
