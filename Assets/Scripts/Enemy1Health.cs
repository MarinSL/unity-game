using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    public float volume;
    public AudioSource impactnoise;
    public int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
             impactnoise.Play(1);
            if (health <= 0)
            {
               
                Destroy(gameObject);
                
            }
        }
    }
}
