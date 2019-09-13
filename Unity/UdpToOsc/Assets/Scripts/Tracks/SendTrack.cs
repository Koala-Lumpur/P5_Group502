using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendTrack : MonoBehaviour
{

    public OscOut oscOut;
    // Start is called before the first frame update
    void Start()
    {
        if (!oscOut) oscOut = gameObject.AddComponent<OscOut>();
        oscOut.Open(9010, "127.0.0.1");
        oscOut.Send("/test", Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        //oscOut.Send("/test", Random.value);
    }
}
