using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject2 : MonoBehaviour
{
void OnMouseDrag() {
    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 6.33f); //
    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    objPosition.x = transform.position.x;
    objPosition.z = transform.position.z;
    transform.position = objPosition * 2.0f;
    }
}


