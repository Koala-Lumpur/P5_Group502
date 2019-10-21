using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody rb;
    public float moveSensitivity = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(this.GetComponent<ClickToActivate>().isActive) {
        float h = Input.GetAxis("Horizontal") * moveSensitivity;
        float v = Input.GetAxis("Vertical") * moveSensitivity;

        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
        }

    }
}
