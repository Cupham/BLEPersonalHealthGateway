using UnityEngine;
using System.Collections;

public class SuperIntEncryption 
{
	public int NUM =0;
	int NUM_DEFAULT =0;
	string KEY = "unitystt";

    static char[] KEYS1 = { 'y', 'f', 'e', 'i', 'o', 't', 'w', 'l', 'k', 'j' };
    static char[] KEYS2 = { 'd', 'f', 'r', 'j', 's', 'g', 'v', 'y', 'z', 'n' };
    static int NUM_D=13;

    public SuperIntEncryption(int initv, string key)
	{
		KEY = key;
        NUM = initv - NUM_D;
        NUM_DEFAULT = NUM;
		Load (); 
	}
	public int Get()
	{
        return NUM + NUM_D;
	}
	public void Set(int x)
	{
        NUM = x - NUM_D;
	}
	public void SetAndSave(int x)
	{
        NUM = x - NUM_D;
		Save ();
	}
	public void Plus(int x)
	{
		NUM += x;
	}
	public void PlusAndSave(int x)
	{
		NUM += x;
		Save ();
	}
	public void Save() 
	{
        PlayerPrefs.SetString(KEY, ToString(NUM));
	}
	public void Load()
	{

        NUM = ToInt(PlayerPrefs.GetString(KEY, ""));
	}
    public string ToString(int num)
    {
        string S = "";
        //int num = NUM; 
        int v;
        if (num < 0) { num = -num; S = "T"; }

        while (num > 0)
        {
            v = num % 10;
            num = num / 10;
            S = KEYS1[v] + S + KEYS2[v];
        }
        return S;
    }
    public int ToInt(string S)
    {
        char c0, c1;
        int i;
        int num=0;
        if (S.Length == 0) return NUM_DEFAULT;
        while(S.Length>1) 
        {
            c0 = S[0];
            c1 = S[S.Length-1];
            S = S.Substring(1, S.Length - 2);
              
            //Debug.Log(c0 + " " + c1);

            for(i =0;i<10;i++)
            {
                if(c0==KEYS1[i])
                {
                    //Debug.Log(c0 + " " + c1);
                    if (c1 == KEYS2[i])
                    {
                        //Debug.Log(c0 + " " + c1);
                        num += i;
                        if(S.Length>1)
                        num *= 10;
                    }
                    else return NUM_DEFAULT;
                    break;
                }
            }

            if(i==10)
            return NUM_DEFAULT;
        }

        if (S.Length == 1) num = -num;
        return num; 
    }
}
