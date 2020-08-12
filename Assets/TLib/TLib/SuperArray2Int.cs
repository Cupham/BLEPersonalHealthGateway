using UnityEngine;
using System.Collections;

public class SuperArray2Int 
{
	public int[][] NUM =null;
	int NUM_DEFAULT =0;
	string KEY = "udstt";
	public int X,Y=0;
	public SuperArray2Int(int x,int y,int initv, string key)
	{
		X = x;
		Y = y;
		KEY = key;
		NUM = new int[X][];
		for (int i=0; i<X; i++)
						NUM [i] = new int[Y];
		NUM_DEFAULT = initv;
		Load ();
	}
	public int Get(int x,int y)
	{
		return NUM[x][y];
	}
	public void Set(int x,int y,int val)
	{
		NUM[x][y] = val;
	}
	public void SetAll(int val)
	{
		for (int i=0; i<X; i++)
			for (int j=0; j<Y; j++)
						Set (i,j, val);
	}
	public void SetAndSave(int x,int y,int val)
	{
		NUM[x][y] = val;
		Save (x,y);
	}
	public void Plus(int x,int y,int val)
	{
		NUM[x][y] += val;
	}
	public void PlusAndSave(int x,int y,int val)
	{
		NUM[x][y] += val;
		Save (x,y);
	}
	public void Save(int x,int y)
	{
		PlayerPrefs.SetInt (x+KEY+y, NUM[x][y]);
	}
	public void Load()
	{
		for (int i=0; i<X; i++)
			for (int j=0; j<Y; j++)
				NUM[i][j] = PlayerPrefs.GetInt (i+KEY+j, NUM_DEFAULT);
	}
	public int CheckExits(int x,int val)
	{
		for (int j=0; j<Y; j++)
			if(NUM[x][j]==val) return j;
		return -1;
	}
}
