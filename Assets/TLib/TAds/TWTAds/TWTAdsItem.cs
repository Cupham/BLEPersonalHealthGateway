using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TWTAdsItem : MonoBehaviour
{
    public string LINK = "https://stgame.vn";
    //string TEXT = "STGAME.VN";
    //static public string SUPER_LINK = "http://clipsquangcao.com/ads/";
    public Image SPRITE;
    public Text LABEL;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetAds(AAdsLabelItem item)
    {
        LABEL.text = item.TEXT;
        SPRITE.sprite = item.SPRITE;
        LINK = item.LINK;
    }
    public void OnClick()
    {
        Application.OpenURL(LINK);
    }
}
