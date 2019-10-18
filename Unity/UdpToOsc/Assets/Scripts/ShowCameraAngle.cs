using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCameraAngle : MonoBehaviour
{
string camRot;
public Camera cam;

  void Update()
  {
      camRot = cam.transform.rotation.eulerAngles.y.ToString();
      gameObject.GetComponent<TextMesh>().text = camRot;
      Debug.Log(camRot);
  }
}
