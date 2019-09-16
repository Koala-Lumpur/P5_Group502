using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrack : MonoBehaviour
{

    public OscIn oscIn;

    // Start is called before the first frame update
    void Start()
    {
        if (!oscIn) oscIn = gameObject.AddComponent<OscIn>();
        oscIn.Open(9010);
        oscIn.MapFloat("/test", OnTest);
    }

    void Update()
    {
        //oscIn.MapFloat("/test", OnTest);
    }

    // Update is called once per frame
    void OnTest(float value)
    {
        Debug.Log(value);
    }
}
