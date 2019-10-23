using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Send : MonoBehaviour

{

    public OscOut oscOut;
    public float xAngle;
    public float yAngle;
    public float MyDistance;
    public float DistanceL;
    public float DistanceR;

    // Start is called before the first frame update
    void Start()
    {

      if (!oscOut) oscOut = gameObject.AddComponent<OscOut>();
      oscOut.Open(8000,"127.0.0.1");
      oscOut.Send("OSC connection established");
      xAngle = gameObject.GetComponent<CalculateAngle>().azimuth;
      yAngle = gameObject.GetComponent<CalculateAngle>().elevation;
      MyDistance = gameObject.GetComponent<GetDistance>().Distance_;
      DistanceL = gameObject.GetComponent<GetAngle>().DistanceL;
      DistanceR = gameObject.GetComponent<GetAngle>().DistanceR;

    }

    // Update is called once per frame
    void Update()
    {
         oscOut.Send("x: ",transform.position.x);
         oscOut.Send("y: ",transform.position.y);
         oscOut.Send("z: ",transform.position.z);

         xAngle = getXAngle();
         yAngle = getYAngle();
         MyDistance = getMyDistance();
         DistanceL = getLeftDistance();
         DistanceR = getRightDistance();

         oscOut.Send("angle: ", xAngle);
         oscOut.Send("y angle: ", yAngle);
        //  oscOut.Send("Distance", MyDistance);
         oscOut.Send("Left: ", DistanceL);
         oscOut.Send("Right: ", DistanceR);


    }

    float getXAngle() {
      float angleValue = gameObject.GetComponent<CalculateAngle>().azimuth;
      return angleValue;
    }

     float getYAngle() {
      float yAngleValue = gameObject.GetComponent<CalculateAngle>().elevation;
      return yAngleValue;
    }

    float getMyDistance() {
      float getDistance = gameObject.GetComponent<GetDistance>().Distance_;
      return getDistance;
    }

    float getLeftDistance() {
      float leftDistance = gameObject.GetComponent<GetAngle>().DistanceL;
      return leftDistance;
    }

    float getRightDistance() {
      float rightDistance = gameObject.GetComponent<GetAngle>().DistanceR;
      return rightDistance;
    }
}
