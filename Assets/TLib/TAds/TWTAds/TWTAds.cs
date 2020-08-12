using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWTAds : TWBoard
{
    public GameObject DEMO;
    public List<TWTAdsItem> list = new List<TWTAdsItem>();
    public void Start()
    {
        base.InitTWBoard();
        DEMO.gameObject.SetActive(false);

       
        if (TAdsManager.I!=null)
        {
            UpdateAds();
        }
        else
        {
            gameObject.AddComponent<TAdsManager>();
        }
    }
    public void UpdateAds()
    {
        foreach (TWTAdsItem item in list)
        {
            Destroy(item.gameObject);
        }
        list.Clear();
        foreach (AAdsLabelItem item in TAdsManager.I.LIST_ADS)
        {
            GameObject g = Instantiate(DEMO.gameObject) as GameObject;
            g.transform.SetParent(DEMO.transform.parent);
            g.SetActive(true);
            g.transform.localScale = Vector3.one;
            g.GetComponent<TWTAdsItem>().SetAds(item);
            list.Add(g.GetComponent<TWTAdsItem>());
        }
    }

    void Update()
    {
        
    }
}
