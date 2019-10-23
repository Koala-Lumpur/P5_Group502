using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCameraWithMouse : MonoBehaviour
{
    public GameObject text;
    public float speedH = 20f;
    public float speedV = 20f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private bool moveCameraPossible = false;
    private bool textVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        speedH = 20f;
        speedV = 20f;   
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(1)) {
            moveCameraPossible = !moveCameraPossible;
            textVisible = !textVisible;
        }

        if(moveCameraPossible) {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        } 

            text.SetActive(textVisible);
        

    }
}
