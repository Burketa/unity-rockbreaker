using System;
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
            if (Utils.isEnemiesPresent())
            {
                Shoot();
                currentShotTimer = 0;
            }
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

        try
        {
            foreach (GameObject enemy in Utils.PossibleEnemies())
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
                    break;
            }

        }
        catch (NullReferenceException exp) { Debug.Log("Ops, sem inimigos para atirar"); }
    }

    private void ShootAt(GameObject enemy)
    {
        //Gira o corpo do canhão para o alvo
        cannonBody.transform.right = enemy.transform.position - transform.position;

        //Atira, instanciando o projetil
        GameObject shot = GameObject.Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.identity, bulletsParent);
    }
}
