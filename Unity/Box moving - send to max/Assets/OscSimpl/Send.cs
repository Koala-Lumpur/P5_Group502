using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Send : MonoBehaviour

{

    public OscOut oscOut;

    // Start is called before the first frame update
    void Start()
    {

      if (!oscOut) oscOut = gameObject.AddComponent<OscOut>();
      oscOut.Open(8000,"127.0.0.1");
      oscOut.Send("OSC connection established");

    }

    // Update is called once per frame
    void Update()
    {
         oscOut.Send("x: ",transform.position.x);
         oscOut.Send("y: ",transform.position.y);
         oscOut.Send("z: ",transform.position.z);

    }
}
