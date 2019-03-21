using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class shoot : MonoBehaviour
{

    int nBullets = 0;
    int nActiveBullets = 0;
    int currentAmmo = 500;
    bool gotBullet;
    float fireRate;
    Transform firePoint;
    GameObject bulletPrefab;

    int nBulletsInPool = 5;//20 - max number of bullets on screen
    List<GameObject> bullets;

    float nextFire = 0;

    public void Shoot(float fr)
    {
        fireRate = fr;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < nBulletsInPool; i++)
            {
                if (bullets[i] != null)
                {
                    if (!bullets[i].activeInHierarchy)
                    {
                        bullets[i].transform.rotation = firePoint.rotation;
                        bullets[i].transform.position = firePoint.position;
                        bullets[i].SetActive(true);
                        break;
                    }
                    else
                    {
                        nActiveBullets++;
                    }
                }
            }

            if (nActiveBullets == nBulletsInPool)
            {
                GameObject bullet;
                bullet = Instantiate(bulletPrefab);
                bullets.Add(bullet);
                bullet.SetActive(false);
                nBulletsInPool++;
                return;
            }
            else { nActiveBullets = 0; }
        }
    }

    void SetBulletsArray()
    {
        GameObject bullet;
        for (int i = 0; i < nBulletsInPool; i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullets.Add(bullet);
            bullet.SetActive(false);
        }
    }

    public void SetBullet(GameObject bullet)
    {
        bulletPrefab = bullet;
        bullets = new List<GameObject>();
        SetBulletsArray();
    }

    public void SetFirePoint(Transform fp)
    {
        firePoint = fp;
    }
    // Use this for initialization
    void Start()
    {

    }

}
