using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float curSpeed;
    float k = 0.3f;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (k <= 1) k += 0.008f; //speed of k change
        else k = 0.5f; // minimum

        curSpeed = GetSpeed(k) * speed;

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * GetSpeed(k) * 0.75f, 0); // 0.8f - k influence
    }

    float GetSpeed(float k)
    {
        if ((k *= 2f) < 1f) return 0.5f * k * k;
        return -0.5f * ((k -= 1f) * (k - 2f) - 1f);  //1f - ((k -= 1f) * k * k * k);
    }
}