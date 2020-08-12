using UnityEngine;
using System.Collections;

public class SuperArrayInt 
{
	public int[] NUM =null;
	int NUM_DEFAULT =0;
	string KEY = "udstt";
	public int N=0;
	public SuperArrayInt(int n,int initv, string key)
	{
		N = n;
		KEY = key;
		NUM = new int[n];
		NUM_DEFAULT = initv;
		Load ();
		//SetAll (10);
		//Save ();
	}
	public int Get(int index)
	{
		return NUM[index];
	}
	public void Set(int index,int x)
	{
		NUM[index] = x;
	}
	public void SetAll(int x)
	{
		for (int i=0; i<N; i++)
						Set (i, x);
	}
	public void SetAndSave(int index,int x)
	{
		NUM[index] = x;
		Save (index);
	}
	public void Plus(int index,int x)
	{
		NUM[index] += x;
	}
	public void PlusAndSave(int index,int x)
	{
		NUM[index] += x;
		Save (index);
	}
	public void Save(int index=-1)
	{
		if(index==-1)
			for(int i=0;i<N;i++)
				PlayerPrefs.SetInt (KEY+i, NUM[i]);
		else PlayerPrefs.SetInt (KEY+index, NUM[index]);
	}
	public void Load()
	{
		for(int i=0;i<N;i++)
			NUM[i] = PlayerPrefs.GetInt (KEY+i, NUM_DEFAULT);
	}
    public void AddItem(int value)
    {
        N++;
        int[] NUM2 = new int[N];
        for (int i = 0; i < NUM.Length; i++)
            NUM2[i] = NUM[i];
        NUM2[N - 1] = value;
        NUM = NUM2;
        Save(N - 1);
    }
}
