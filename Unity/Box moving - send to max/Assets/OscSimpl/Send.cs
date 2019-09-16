using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Send : MonoBehaviour

{

    public OscOut oscOut;
    public float myAngle;
    public float myYAngle;

    // Start is called before the first frame update
    void Start()
    {

      if (!oscOut) oscOut = gameObject.AddComponent<OscOut>();
      oscOut.Open(8000,"127.0.0.1");
      oscOut.Send("OSC connection established");
      myAngle = gameObject.GetComponent<GetAngle>().angle;
      myYAngle = gameObject.GetComponent<GetAngle>().yAngle;

    }

    // Update is called once per frame
    void Update()
    {
         oscOut.Send("x: ",transform.position.x);
         oscOut.Send("y: ",transform.position.y);
         oscOut.Send("z: ",transform.position.z);
         myAngle = getXAngle();
         myYAngle = getYAngle();
         oscOut.Send("angle: ", myAngle);
         oscOut.Send("y angle: ", myYAngle);


    }

    float getXAngle() {
      float angleValue = gameObject.GetComponent<GetAngle>().angle;
      return angleValue;
    }

     float getYAngle() {
      float yAngleValue = gameObject.GetComponent<GetAngle>().yAngle;
      return yAngleValue;
    }
}
