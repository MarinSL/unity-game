﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed = 10f;
    [SerializeField]
    int damage;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //set active
        rb.velocity = transform.up * speed;
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("bullet"))
        {
            gameObject.SetActive(false);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}