using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_shopTable  
{
private static st_shopTable _instance;
public Dictionary<int, st_shop> VALUE;
public st_shopTable()
{
	VALUE = new Dictionary<int, st_shop>();
}
public static st_shopTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_shopTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_shop Get(int id)
{
return VALUE[id];
}
public void load()
{
st_shop t;
t = new st_shop();
t.id=0;
t.stringid="com.csgame.defend.coin1";
t.coin=100;
t.gem=0;
t.is_ads=false;
t.icon="no";
t.usd=1;
VALUE.Add(0, t);

t = new st_shop();
t.id=1;
t.stringid="com.csgame.defend.gem1";
t.coin=0;
t.gem=200;
t.is_ads=false;
t.icon="no";
t.usd=1;
VALUE.Add(1, t);

t = new st_shop();
t.id=2;
t.stringid="com.csgame.defend.coin5";
t.coin=600;
t.gem=0;
t.is_ads=false;
t.icon="no";
t.usd=5;
VALUE.Add(2, t);

t = new st_shop();
t.id=3;
t.stringid="com.csgame.defend.gem5";
t.coin=0;
t.gem=1200;
t.is_ads=false;
t.icon="no";
t.usd=5;
VALUE.Add(3, t);

t = new st_shop();
t.id=4;
t.stringid="com.csgame.defend.coin10";
t.coin=1300;
t.gem=0;
t.is_ads=false;
t.icon="no";
t.usd=10;
VALUE.Add(4, t);

t = new st_shop();
t.id=5;
t.stringid="com.csgame.defend.gem10";
t.coin=0;
t.gem=4000;
t.is_ads=false;
t.icon="no";
t.usd=10;
VALUE.Add(5, t);

t = new st_shop();
t.id=6;
t.stringid="com.csgame.defend.removeads";
t.coin=0;
t.gem=0;
t.is_ads=true;
t.icon="no";
t.usd=1;
VALUE.Add(6, t);
}
public static st_shop getst_shopByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
