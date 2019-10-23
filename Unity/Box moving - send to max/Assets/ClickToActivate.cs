using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToActivate : MonoBehaviour
{

    // public GameObject myObject;
    bool textActive = false;
    Color[] colors = new Color[] {Color.blue, Color.red};
    private int currentColor, length;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {

        currentColor = 0;
        length = colors.Length;
        // myObject.material.color = colors[currentColor];
    }

    void OnMouseDown()
    {
        isActive = !isActive;
    }
    // Update is called once per frame
    void Update()
    {

        // if(isActive) {
        //     Debug.Log(isActive);
        // }
        
    }
}
