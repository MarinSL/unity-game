using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttackScript : MonoBehaviour
{
    [SerializeField]
    float Speed = 10f;
    [SerializeField]
    float RestoreValue;
    [SerializeField]
    float DecreaseValue;
    [SerializeField]
    int damage;
    Rigidbody2D rb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerHealth>().DecreaseHealth(DecreaseValue);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (!collision.gameObject.CompareTag("bullet"))
        {
            if (player != null) { player.GetComponent<PlayerHealth>().RestoreHealth(RestoreValue); Debug.Log("Restored");
            } else Debug.Log("Player is null");

            if (collision.gameObject.GetComponent<EnemyHealth>() != null)
            {
                collision.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();
            }
            else Debug.Log("Enemy health is null");

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (!collision.gameObject.CompareTag("bullet"))
        {
            if (player != null) { player.GetComponent<PlayerHealth>().RestoreHealth(RestoreValue); Debug.Log("Restored"); } else Debug.Log("Player is null");
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return damage;
    }
}