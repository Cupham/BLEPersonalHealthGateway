using UnityEngine;
using System.Collections;

public class TU
{
	static bool IS_NIT = false;
	static public Object ARROW;
	static public Object LEVEL_UP;
	static public Vector3 LEVEL_UP_POS = new Vector3(0,-30,0.1f);
	static public Vector3 LEVEL_UP_SCALE = new Vector3(8,8,8);
	static public Object[] MANS;
	static public Object[] HEROES;
	static public Object[] LABEL_LEVES;
	static public Object[] HITS;
	static public int NUM_HERO = 4;
	static public void Init()
	{
		if (IS_NIT) return;
		ARROW = Resources.Load ("arrow");
		MANS = new Object[2];
		for(int i=0;i<MANS.Length;i++)
			MANS[i] = Resources.Load ("Mans/Man"+i);
		HEROES = new Object[NUM_HERO];
		LABEL_LEVES = new Object[18];
		HITS = new Object[10];
		IS_NIT = true;
	}
	public static Object GetHitsObject(int index)
	{
		if(HITS[index]==null)
			HITS[index] = Resources.Load ("hit"+index);
		return HITS [index];
	}
	public static Object GetHeroObject(int index)
	{
		if(HEROES[index]==null)
			HEROES[index] = Resources.Load ("Mans/Hero"+index);
		return HEROES [index];
	}
	public static Object Get_LABEL_LEVES(int index)
	{
		if(LABEL_LEVES[index]==null)
			LABEL_LEVES[index] = Resources.Load ("textlevels/text_level_"+index);
		return LABEL_LEVES [index];
	}
	public static Object Get_LEVEL_UP()
	{
		if(LEVEL_UP==null)
			LEVEL_UP = Resources.Load ("Skills/LEVEL_UP");
		return LEVEL_UP;
	}
    //public static bool InSide(Vector2 v,Transform collider)
    //{
    //    float hwidth = collider.collider.bounds.size.x * 80;
    //    float hheight = collider.collider.bounds.size.y * 80;
    //    float x = collider.transform.position.x - GamePlay.CAM_S.transform.position.x;
    //    float y = collider.transform.position.y - GamePlay.CAM_S.transform.position.y;
    //    x *= 160;
    //    y *= 160;
    //    if (v.x < x - hwidth)return false; 
    //    if (v.x > x + hwidth) return false;
    //    if (v.y < y - hheight) return false;
    //    if (v.y > y + hheight)return false;
    //    return true;
    //}
    //public static bool InSide2D(Vector2 v,Transform collider)
    //{
    //    //if (collider.collider != null) return false;

    //    //Debug.Log ("1234");
    //    float hwidth = ((BoxCollider2D)collider.collider2D).size.x ;
    //    float hheight = ((BoxCollider2D)collider.collider2D).size.y ;

    //    float x = collider.transform.position.x - GamePlay.CAM_S.transform.position.x;
    //    float y = collider.transform.position.y - GamePlay.CAM_S.transform.position.y;
    //    x *= 160;
    //    y *= 160;
    //    if (v.x < x - hwidth)return false; 
    //    if (v.x > x + hwidth) return false;
    //    if (v.y < y - hheight) return false;
    //    if (v.y > y + hheight)return false;
    //    return true;
    //}
	public static int[] stringtoArray(string s)
	{

		string[] s1 = s.Split (',');
		int n = s1.Length;
		int[] a = new int[n];
		for (int i =0; i<n; i++) 
		{
			if(s1[i]!="")
			a[i] = int.Parse(s1[i]);
		}
		return a;

	}
	public static string LAST_LEVEL_NAME;
    public static string SecondToMinues(int time)
    {
        int mun = time / 60;
        int second = time % 60;
        //Debug.Log("time = " + time + " string="+mun + ":" + second);
        return mun + ":" + second;
    }
    static public float DistanceFast2D(Vector3 v0, Vector3 v1)
    {
        return Mathf.Abs(v0.x - v1.x) + Mathf.Abs(v0.y - v1.y);
    }
}
