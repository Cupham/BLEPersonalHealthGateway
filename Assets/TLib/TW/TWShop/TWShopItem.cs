using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TWShopItem : MonoBehaviour
{
    public int ID;
    public Text TEXT;
    st_shop ST_SHOP;
	void Start ()
    {
        //Debug.Log(ID);
        string s = "+";
        ST_SHOP = st_shopTable.getst_shopByID(ID);
        if(ST_SHOP.is_ads == true)
        {
            TEXT.text = "Remove ads \n" + ST_SHOP.usd + "$";
            
        }
        else
        {
            if(ST_SHOP.coin>0)
            {
                s += ST_SHOP.coin + " COIN \n" + ST_SHOP.usd + "$";
            }
            else
            {
                s += ST_SHOP.gem + " GEM \n" + ST_SHOP.usd + "$";
            }
            TEXT.text = s;
        }

        
    }
	void Update ()
    {
		
	}
    public void OnClick()
    {
        //TWShop.I.UserClick(ST_SHOP);
    }
}
