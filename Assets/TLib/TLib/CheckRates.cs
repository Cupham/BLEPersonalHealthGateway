using UnityEngine;
using System.Collections;

public class CheckRates : MonoBehaviour
{
    public static SuperInt NUMBER_GAME_OPEN ;
    public static SuperInt NUMBER_CLICK_YES;
    static CheckRates I;
    void Start ()
    {
        if (I != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        NUMBER_GAME_OPEN = new SuperInt(0, "dfksldjf");

        NUMBER_CLICK_YES = new SuperInt(0, "dfksldjchick");
        if (NUMBER_CLICK_YES.Get() > 2) return;
        
        NUMBER_GAME_OPEN.PlusAndSave(1);
        if (NUMBER_GAME_OPEN.Get() % 10 ==0)
        {
            TW.I.AddWarningYN("", "Bạn có muốn đánh giá 5 sao cho game này không ?", click_yes); 
        }
    }
    public void click_yes()
    {
        NUMBER_CLICK_YES.PlusAndSave(1);
        TI.ClickRate();
    }
    void Update ()
    {
	
	}
}
