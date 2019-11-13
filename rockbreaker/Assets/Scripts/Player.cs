using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletsParent;
    public Transform bulletShootPoint;
    public Transform cannonBody;

    private float shotCooldown;
    private float currentShotTimer;

    private void Awake()
    {
        shotCooldown = PlayerStats.fireRate;
        currentShotTimer = shotCooldown;
    }

    void Update()
    {
        shotCooldown = PlayerStats.fireRate;
        CheckIfCanShoot();
    }

    private void CheckIfCanShoot()
    {
        if (Utils.CheckTimer(currentShotTimer, shotCooldown))
        {
            Shoot();
            currentShotTimer = 0;
        }
        else
        {
            currentShotTimer += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        int shotCount = PlayerStats.shotCount;
        int currentShotCount = 0;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                if (currentShotCount < shotCount)
                {
                    if (enemy.transform.position.y > transform.position.y)
                    {
                        ShootAt(enemy);
                        currentShotCount++;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void ShootAt(GameObject enemy)
    {
        cannonBody.transform.right = enemy.transform.position - transform.position;

        GameObject shot = GameObject.Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.identity, bulletsParent);
        shot.GetComponent<Bullet>().SetTarget(enemy);
        //var dir = enemy.transform.position - bulletShootPoint.position;
        //cannonBody.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.x / dir.y)));
    }
}
