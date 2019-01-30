using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class shoot : MonoBehaviour {

    public int nBullets = 0 ;
    int currentAmmo = 500;
    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefab;

    int nBulletsInPool = 20;//20 - max number of bullets on screen
    List<GameObject> bullets; 

    float nextFire;

    void Shoot()
    {
       /* if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;*/
            nBullets++;
            if (nBullets >= nBulletsInPool) nBullets = 0;
            if(!bullets[nBullets].activeInHierarchy)
            {
                //shoot in the direction of the weapon/player
                bullets[nBullets].transform.rotation = firePoint.rotation;
                bullets[nBullets].transform.position = firePoint.position;
                bullets[nBullets].SetActive(true);
            }
          /*  currentAmmo--;
        }*/
    }

    void setBulletsArray()
    {
        GameObject bullet;
        for (int i = 0; i<nBulletsInPool;i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullets.Add(bullet);
            bullet.SetActive(false);
        }

    }

    // Use this for initialization
    void Start()
    {
        bullets = new List<GameObject>();
        setBulletsArray();
    }

    
	// Update is called once per frame
	void Update () {
		if (currentAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("meow");
                Shoot();
            }
        }
	}
}
