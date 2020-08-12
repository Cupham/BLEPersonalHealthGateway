using UnityEngine;
using System.Collections;

public class Vec2 
{
	public int R;
	public int C;

    public Vec2()
    {
        R = 0;
        C = 0;
    }

	public Vec2(int r,int c)
	{
		R = r;
		C = c;
	}
	public Vec2(Vector2 vec)
	{
		R = (int)vec.y;
		C = (int)vec.x;
	}
	public Vec2(Vec2 vec)
	{
		R = vec.R;
		C = vec.C;
	}
    public void CopyFrom(Vec2 vec)
    {
        R = vec.R;
        C = vec.C;
    }
	static int r, c;
	static public int FastDistance(Vec2 v1, Vec2 v2)
	{
		r = Mathf.Abs (v1.R - v2.R);
		c = Mathf.Abs (v1.C - v2.C);
		if(r>c) return r;
		return c;
	}

	public string Print()
	{
        string r = "(" + R + "," + C + ")";
        return r;
	}
    public static Vec2 operator +(Vec2 c1, Vec2 c2)
    {
        return new Vec2(c1.R + c2.R, c1.C + c2.C);
    }
    public static Vec2 operator -(Vec2 c1, Vec2 c2)
    {
        return new Vec2(c1.R - c2.R, c1.C - c2.C);
    }
    public bool Bang(Vec2 t)
    {
        if (R != t.R) return false;
        if (C != t.C) return false;
        return true;
    }
    //public static bool operator == (Vec2 c1, Vec2 c2)
    //{
    //    if (c1.R != c2.R) return false;
    //    if (c1.C != c2.C) return false;
    //    return true;
    //}
    //public static bool operator !=(Vec2 c1, Vec2 c2)
    //{
    //    if (c1 == null && c2 == null) return true;
    //    if (c1 == null) return false; 
    //    if (c2 == null) return false;
    //    if (c1.R == c2.R && c1.C == c2.C) return false;
    //    return true;
    //}
}
