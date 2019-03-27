using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public AudioSource impactnoise;
    
    public float pitchmax;
    public float pitchmin;
    public ParticleSystem deatheffect;
    public void DecreaseHealth()
    {
        Debug.Log("decreased");
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health--;
            impactnoise.Play(1);
            impactnoise.pitch = Random.Range(pitchmin, pitchmax);
        }

        else if (collision.gameObject.CompareTag("bullet"))
        {
            if (collision.gameObject.GetComponent<bulletScript>() != null)
                health -= collision.gameObject.GetComponent<bulletScript>().GetDamage();
            else if (collision.gameObject.GetComponent<SecondaryAttackScript>() != null)
                health -= collision.gameObject.GetComponent<SecondaryAttackScript>().GetDamage();
        }
        if (health <= 0)
        {
            Instantiate(deatheffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}