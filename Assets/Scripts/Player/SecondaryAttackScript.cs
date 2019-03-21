using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttackScript : MonoBehaviour
{
    [SerializeField]
    float Speed = 10f;
    [SerializeField]
    float RestoreValue;
    Rigidbody2D rb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (!collision.gameObject.CompareTag("bullet"))
        {
            if (player != null) { player.GetComponent<PlayerHealth>().RestoreHealth(RestoreValue); Debug.Log("Restored"); } else Debug.Log("Player is null");
        }
    }
    void OnBecameInvisible()
    {
        Debug.Log("invisible");
        Destroy(gameObject);
    }
}