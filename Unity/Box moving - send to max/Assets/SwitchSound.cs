using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{

    public bool buttonPressed;
    public int number;
    // // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
        // number = 0;
    }


    void OnMouseDown()
    {
        buttonPressed = !buttonPressed;
        

    }
    
    void OnMouseUp(){
        
        buttonPressed = !buttonPressed;
        
    }

    void update() {

        // if(Input.GetMouseButtonDown(0)) {
        //     buttonPressed = !buttonPressed;
        // }

    }
}
