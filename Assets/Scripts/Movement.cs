using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public int speed;
    Rigidbody2D rb;
    


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, 0);
       
    }
}
