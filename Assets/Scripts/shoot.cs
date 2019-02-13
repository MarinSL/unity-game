using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class shoot : MonoBehaviour {

    int nBullets = 0 ;
    int nActiveBullets = 0;
    int currentAmmo = 500;
    bool gotBullet;
    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefab;

    int nBulletsInPool = 5;//20 - max number of bullets on screen
    List<GameObject> bullets; 

    float nextFire;

    void Shoot()
    {
       /* if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;  //in case we need */
            for (int i = 0; i < nBulletsInPool; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    bullets[i].transform.rotation = firePoint.rotation;
                    bullets[i].transform.position = firePoint.position;
                    bullets[i].SetActive(true);
                    break;
                } else
                {
                    nActiveBullets++;
                }
            }

            if(nActiveBullets==nBulletsInPool)
            {
                GameObject bullet;
                bullet = Instantiate(bulletPrefab);
                bullets.Add(bullet);
                bullet.SetActive(false);
                nBulletsInPool++;
                return;
            } else { nActiveBullets = 0; }

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
                Shoot();
            }
        }
	}
}
