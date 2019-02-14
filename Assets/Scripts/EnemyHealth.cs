using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            health--;
            if(health <= 0)
            {
                Destroy(gameObject);
            } 
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
