using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupeArayString : MonoBehaviour {

    public int N;
    public SuperString[] STRINGS;
    public SupeArayString(int n, string initv, string key)
    {
        N = n;
        STRINGS = new SuperString[N];
        for (int i = 0; i < N; i++)
        {
            STRINGS[i] = new SuperString(initv, key + i);
        }
    }
    public string Get(int index)
    {
        return STRINGS[index].STR;
    }
    public void SetAndSave(int index, string x)
    {
        STRINGS[index].STR = x;
        STRINGS[index].Save();
    }
   
   
    
}
