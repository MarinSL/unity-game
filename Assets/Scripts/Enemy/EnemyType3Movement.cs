using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3Movement : MonoBehaviour
{
    public float movementWidth;
    Vector3 down;
    Vector3 targetDir;

    GameObject player;
    public Transform firePoint;

    public GameObject bullet;
    public float angle;
    float nextFire = 0;
    float fireRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position += new Vector3(0, - 100, 0);
        GetComponent<shoot>().SetBullet(bullet);
        GetComponent<shoot>().SetFirePoint(firePoint);
    }

    void Move()
    {
        transform.position = new Vector3(movementWidth * Mathf.Sin(Time.time), transform.position.y, transform.position.z);
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            GetComponent<shoot>().Shoot(0);
            nextFire = Time.time + fireRate;
        }
    }

    bool PlayerIsNear()
    {
        down = transform.up * -1;
        if (player != null)
            targetDir = player.transform.position - transform.position;
        else return false;

        angle = Mathf.Abs(Vector3.Angle(targetDir, down));
        if (angle < 10)
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
