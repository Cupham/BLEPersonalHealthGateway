using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TWWarningInput : TWBoard
{
    public InputField input;
	void Start () 
    {
        base.InitTWBoard();
	}
	void Update () 
    {
	
	}
     override public void ClickYES()
    {
        Debug.Log(input.text);
        onyes();
    }
    
}
