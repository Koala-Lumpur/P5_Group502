using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
  public int layermask;
  public LineRenderer line;
  public Material matNotHit;
  public Material matHit;

    // Start is called before the first frame update
    void Start()
    {
      line = gameObject.GetComponent<LineRenderer>();
      layermask = 1 << 8;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
      Vector3 endPos = transform.position + forward;

      line.SetPosition(0, transform.position);
      line.SetPosition(1, endPos);

      RaycastHit hit;
      if(Physics.Raycast(transform.position, forward, out hit, Mathf.Infinity, layermask)) {
        line.material = matHit;
      } else {
        line.material = matNotHit;
      }
    }
}
