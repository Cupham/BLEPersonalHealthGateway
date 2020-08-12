using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

public class a1233 : MonoBehaviour
{
    // Start is called before the first frame update

    string s = "";
    void Start()
    {
        var client = new FhirClient("http://hapi.fhir.org/baseR4");
        var pat_A = client.Read<Patient>("Patient/1425399");
        Debug.Log("TOAN100:" + pat_A.Name[0].Family);
        s = pat_A.Name[0].Family;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, 200, 60), s);
    }

}
