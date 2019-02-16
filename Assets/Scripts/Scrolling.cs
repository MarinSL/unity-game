﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private Rigidbody2D rb;
    public float scrollingSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, scrollingSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
