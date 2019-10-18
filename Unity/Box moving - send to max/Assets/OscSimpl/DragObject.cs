﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class DragObject : MonoBehaviour

{

    private Vector3 mOffset;
    private Vector3 objectposition;



    private float mZCoord;



    void OnMouseDown()

    {
        objectposition = gameObject.transform.position;
        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        objectposition.x = transform.position.x;
        objectposition.z = transform.position.z;
        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

}