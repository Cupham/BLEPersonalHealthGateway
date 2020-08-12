using UnityEngine;
using System.Collections;

public class testtads : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log(Application.loadedLevelName);

	}
	
	// Update is called once per frame
	void Update () 
    {
	if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log(1);
            if (Application.loadedLevelName == "tads") Application.LoadLevel("tads2");
            else Application.LoadLevel("tads");
            
        }
	}
}
