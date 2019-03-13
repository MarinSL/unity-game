using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    float Delay1 = 0;
    [SerializeField]
    float Delay2 = 0;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public Transform firePoint;
    float nextFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<shoot>().SetBullet(bulletPrefab1);
        GetComponent<shoot>().SetFirePoint(firePoint);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))    
        {
            GetComponent<shoot>().Shoot(Delay1);
        }
        if(Input.GetButtonDown("Fire2"))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + Delay2;
                GameObject bullet;
                bullet = Instantiate(bulletPrefab2);
                bullet.transform.rotation = firePoint.rotation;
                bullet.transform.position = firePoint.position;
            }
        }
    }
}
