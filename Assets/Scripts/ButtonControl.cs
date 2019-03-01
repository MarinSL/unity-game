using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

    public bool isStart;
    public bool isQuit;
    // Use this for initialization
    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel(3);
           
        }
        if (isQuit)
        {
            Application.Quit();
            
        }
    }
}
