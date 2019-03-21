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
    float initPosX;
    [SerializeField]
    float Yspeed = 50;
    [SerializeField]
    float Xspeed = 5;
    float targetPositionY;
    bool goingDown = true;
    bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        // transform.position += new Vector3(0, - 100, 0);
        GetComponent<shoot>().SetBullet(bullet);
        GetComponent<shoot>().SetFirePoint(firePoint);
        initPosX = transform.position.x;
        targetPositionY = transform.position.y - 100;
    }
    void MoveDown()
    {
        transform.position = new Vector3(initPosX + 50 * Mathf.Sin(2 * Mathf.PI * Time.time), transform.position.y - Yspeed * Mathf.Abs(Mathf.Sin(Mathf.PI / 200)), transform.position.z);
        if (transform.position.y <= targetPositionY) goingDown = false;
    }
    void Move()
    {
        transform.position = new Vector3(transform.position.x + Xspeed, transform.position.y, transform.position.z);

        // transform.position = new Vector3(initPosX + Mathf.Sin(Time.time)*movementWidth/2, transform.position.y, transform.position.z);
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
        if (goingDown) MoveDown();
        else
        {
            Move();
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "border") Xspeed *= -1;
    }
}