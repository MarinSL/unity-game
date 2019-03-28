using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    Sprite withWeapon;
    [SerializeField]
    Sprite withoutWeapon;

    Rigidbody2D rb;
    SpriteRenderer sr;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(bool withWeaponBool)
    {
        if (withWeaponBool)
            sr.sprite = withWeapon;
        else sr.sprite = withoutWeapon;
    }
    // Update is called once per frame
    void Update()
    {
        if (speed + acceleration <= maxSpeed)
            speed += acceleration;

        rb.velocity = Input.GetAxisRaw("Horizontal") * speed * Vector2.right;
    }
}