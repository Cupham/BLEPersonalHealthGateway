using UnityEngine;
using System.Collections;

public class TBitmapFontGen : MonoBehaviour 
{
    public static TBitmapFontGen I;
    public Sprite[] SPRITES;
    float D_X;
    public float SCALE_DX = 0.7f;
    void Awake()
    {
        I = this;
        D_X = SPRITES[0].bounds.size.x ;
    }
	void Start () 
    {
        GenBitmapfontnumber(54322);
	}
	
    void Update () 
    {
	
	}
    public void GenBitmapfontnumber(int number)
    {
        D_X *= SCALE_DX;
        GameObject g2 = new GameObject();
        int num_ = (int)Mathf.Log10(number);
        float size_total = num_ * D_X / 2 - 2*D_X/2;
        int c;
        int index = num_-1;
        while(number >0)
        {
            c = number % 10;
            number /= 10;

            GameObject g = new GameObject();
            g.transform.SetParent(g2.transform);
            g.AddComponent<SpriteRenderer>().sprite = SPRITES[c];

            g.transform.localPosition = new Vector3(index * D_X - size_total, 0, 0);

            index--;
        }
    }
}
