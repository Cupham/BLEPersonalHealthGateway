using UnityEngine;
using System.Collections;

public class SuperArrayInt_List 
{
	public int[] NUM =null;
	int NUM_DEFAULT =0;
	string KEY = "udstt";
    public SuperInt N;
    public SuperArrayInt_List(int n, int initv, string key)
	{
        N = new SuperInt(n, key + key);
		KEY = key;
        NUM = new int[N.Get()];
		NUM_DEFAULT = initv;
		Load ();
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
		for (int i=0; i<N.Get(); i++)
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
            for (int i = 0; i < N.Get(); i++)
				PlayerPrefs.SetInt (KEY+i, NUM[i]);
		else PlayerPrefs.SetInt (KEY+index, NUM[index]);
	}
	public void Load()
	{
        for (int i = 0; i < N.Get(); i++)
			NUM[i] = PlayerPrefs.GetInt (KEY+i, NUM_DEFAULT);
	}
    public void AddItem(int value)
    {

        N.PlusAndSave(1);
        int[] NUM2 = new int[N.Get()];
        for (int i = 0; i < NUM.Length; i++)
            NUM2[i] = NUM[i];
        NUM2[N.Get() - 1] = value;
        NUM = NUM2;
        Save(N.Get() - 1);
    }
    public void RemovebyIndex(int index)
    {
        if (N.Get() <= 0) return;
        if (index < 0 || index >= N.Get()) return;

        for(int i = index; i < N.Get()-1; i++)
        {
            NUM[i] = NUM[i + 1];
            Save(i);
        }
        N.PlusAndSave(-1);
    }
}
