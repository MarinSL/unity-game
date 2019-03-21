using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    public float pitchmax;
    public float pitchmin;
    public float volume;
    public AudioSource impactnoise;
    public int health;
    public ParticleSystem deatheffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            impactnoise.Play(1);
            impactnoise.pitch = Random.Range(pitchmin, pitchmax);
            if (health <= 0)
            {
                Instantiate(deatheffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
