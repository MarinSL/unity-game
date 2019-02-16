using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3Movement : MonoBehaviour
{
    public float movementWidth;
    public Vector3 down;

    Vector3 targetDir;

    GameObject player;
    GameObject bullet;

<<<<<<< HEAD
    float angle;
=======
    public float angle;
>>>>>>> 3rd enemy + bullet collision
    float nextFire = 0;
    float fireRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Move()
    {
        transform.position = new Vector3(movementWidth * Mathf.Sin(Time.time), transform.position.y, transform.position.z);
    }

    void Shoot()
    {
<<<<<<< HEAD
        if (Time.time > nextFire && PlayerIsNear())
=======
        if (Time.time >= nextFire && PlayerIsNear())
>>>>>>> 3rd enemy + bullet collision
        {
            nextFire = Time.time + fireRate;
            GetComponent<shoot>().Shoot();
        }
        else return;
    }

    bool PlayerIsNear()
    {
        down = transform.up * -1;
        if (player != null)
            targetDir = player.transform.position - transform.position;
        else return false;

        angle = Mathf.Abs(Vector3.Angle(targetDir, down));
<<<<<<< HEAD
        if (angle < 20)
=======
        if (angle < 10)
>>>>>>> 3rd enemy + bullet collision
        {
            return true;
        }
        else return false;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }
}
