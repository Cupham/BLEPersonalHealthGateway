using UnityEngine;
using System.Collections;

public class TO
{
	static public float WIDTH;
    static public float HEIGHT;
    static public float WIDTH_HALF;
    static public float HEIGHT_HALF;
    static public float RATIO;
    static public float RATIO_ORTHOR_CHIA_SCREEN;
    static public float SCREEN_WIDTH_HALF;
    static public float SCREEN_HEIGHT_HALF;
    static public Vector3 SCREEN_HALF;
    static TO()
    {
        HEIGHT = Camera.main.orthographicSize * 2;
        RATIO = Screen.width * 1.0f / Screen.height;
        WIDTH = RATIO * HEIGHT;
        WIDTH_HALF = WIDTH / 2;
        HEIGHT_HALF = HEIGHT / 2;

        RATIO_ORTHOR_CHIA_SCREEN = WIDTH / Screen.width;

        SCREEN_WIDTH_HALF = Screen.width * 0.5f;
        SCREEN_HEIGHT_HALF = Screen.height * 0.5f;
        SCREEN_HALF = new Vector3(SCREEN_WIDTH_HALF, SCREEN_HEIGHT_HALF);
    }



    public static Vector3 Pixel2Othor(Vector3 vec)
    {
        return (vec - SCREEN_HALF) * RATIO_ORTHOR_CHIA_SCREEN;
    }
    public static Vector3 Othor2Pixcel(Vector3 vec)
    {
        return vec / RATIO_ORTHOR_CHIA_SCREEN + SCREEN_HALF;
        //return (vec - SCREEN_HALF) * RATIO_ORTHOR_CHIA_SCREEN;
    }
    public static Vector3 Othor2Canvas(Vector3 vec)
    {
        return vec *60;
    }
    public static Vector3 Pixel2OCanvas(Vector3 vec)
    {
        return (vec - SCREEN_HALF) * RATIO_ORTHOR_CHIA_SCREEN*60;
    }

    ////public static Vector3 Pixel2Othor(float x,float y)
    ////{
    //    //return new Vector3 (x *RATIO_ORTHOR_X,y *RATIO_ORTHOR_Y,0 );
    ////}
    ////public static Vector2 Pixel2OthorVec2(float x,float y)
    ////{
    //    //return new Vector2 (x *RATIO_ORTHOR_X,y *RATIO_ORTHOR_Y );
    ////}
    //public static Vector3 Pixel2Othor(float x,float y,float z)
    //{
    //    return new Vector3 (x *RATIO_ORTHOR_X,y *RATIO_ORTHOR_Y,z );
    //}
    //public static Vector3 Pixel2OthorAmDuong(Vector3 vec)
    //{
    //    return new Vector3 (vec.x *RATIO_ORTHOR_X - WIDTH_ORTHO_HALF,vec.y *RATIO_ORTHOR_Y-HEIGHT_ORTHO_HALF,vec.z );
    //}
    //public static Vector2 Pixel2OthorAmDuongVec2(float x,float y)
    //{
    //    return new Vector2 (x *RATIO_ORTHOR_X - WIDTH_ORTHO_HALF,y *RATIO_ORTHOR_Y-HEIGHT_ORTHO_HALF );
    //}
    //public static Vector2 Pixel2PixelAmDuongVec2(float x,float y)
    //{
    //    return new Vector2 (x - WIDTH_HALF,y -HEIGHT_HALF );
    //}
}

