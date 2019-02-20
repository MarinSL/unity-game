using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour {
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
    }

    void OnMouseEnter()
    {
        Debug.Log("on mouse enter");
        rend.material.color = Color.red;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.black;
       
    }
}
