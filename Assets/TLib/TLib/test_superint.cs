using UnityEngine;
using System.Collections;

public class test_superint : MonoBehaviour 
{
	void Start () 
    {
        SuperIntEncryption i = new SuperIntEncryption(65666, "rt");
        
        //Debug.Log(i.Get());
        //i.PlusAndSave(-1);
        //Debug.Log(i.Get());
        //i.PlusAndSave(1);
        //Debug.Log(i.Get());

        Debug.Log(i.ToString(-9234296));
        Debug.Log(i.ToInt(""));


	}
	void Update () 
    {
	
	}
}
