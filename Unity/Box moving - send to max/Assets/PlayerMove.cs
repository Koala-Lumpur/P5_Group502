using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody rb;
    public float moveSensitivity = 15;
    public Transform cam;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(this.GetComponent<ClickToActivate>().isActive) {

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        // float h = Input.GetAxis("Horizontal") * moveSensitivity;
        // float v = Input.GetAxis("Vertical") * moveSensitivity;

        // Vector3 vel = rb.velocity;
        // vel.x = h;
        // vel.z = v;
        // rb.velocity = vel;

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * moveSensitivity;


        }

    }
}
