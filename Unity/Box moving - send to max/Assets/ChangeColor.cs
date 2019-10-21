// Drag this script on the object we want to change the color of

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private Material material1;
    // public Material material2;

    bool FirstMaterial = true;
    // Start is called before the first frame update
    void Start()
    {
        material1 = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Sphere").GetComponent<ClickToActivate>().isActive) {
             
            material1.color = Color.red;
 
         } else {
             material1.color = Color.blue;
         }
    }
}
