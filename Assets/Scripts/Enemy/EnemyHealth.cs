using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
  //  public AudioSource impactenemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet") || collision.gameObject.CompareTag("Player"))
        {
            health--;
          //  impactenemy.Play(1);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
