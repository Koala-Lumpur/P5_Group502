using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(GameObject.Find("Cube").GetComponent<ClickToActivate>().isActive) {
        float h = Input.GetAxis("Horizontal") * 25;
        float v = Input.GetAxis("Vertical") * 25;

        Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;
        }

    }
}
