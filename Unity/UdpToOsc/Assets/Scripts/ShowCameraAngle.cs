using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCameraAngle : MonoBehaviour
{
string camRot;

  void Start()
  {
      camRot = Camera.main.transform.rotation.eulerAngles.y.ToString();
      gameObject.GetComponent<TextMesh>().text = camRot.ToString();
      Debug.Log(camRot);
  }
}
