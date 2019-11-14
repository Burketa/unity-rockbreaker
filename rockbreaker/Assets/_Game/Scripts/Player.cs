using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public GameObject bulletPrefab;
    public Transform bulletsParent;
    public Transform bulletShootPoint;
    public Transform cannonBody;

    private float shotCooldown;
    private float currentShotTimer;

    private bool isDead = false;

    private void Awake()
    {
        shotCooldown = PlayerStats.fireRate;
        currentShotTimer = shotCooldown;
        player = this;
        PlayerStats.Reset();
    }

    void Update()
    {
        if (isDead)
        {
            Utils.RestartLevel();
        }
        else
        {
            shotCooldown = PlayerStats.fireRate;
            CheckIfCanShoot();
        }
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
        try
        {
            foreach (GameObject enemy in Utils.PossibleEnemies())
            {
                if (enemy.transform.position.y > transform.position.y)
                {
                    AimAt(enemy);
                    for (int shots = 1; shots <= PlayerStats.shotCount; shots++)
                        DoShoot(shots);
                    break;
                }
            }
        }
        catch (NullReferenceException exp) { Debug.Log("Ops, sem inimigos para atirar"); }
    }

    private void AimAt(GameObject enemy)
    {
        //Gira o corpo do canhão para o alvo
        cannonBody.transform.right = enemy.transform.position - transform.position;

        GetComponent<Animation>().Play("player-shoot");
    }

    private void DoShoot(int shots)
    {
        //Atira, instanciando o projetil
        GameObject shot = GameObject.Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.identity, bulletsParent);
    }

    public void TakeDamage(int dmg)
    {
        //TODO: Shake Camera
        PlayerStats.score -= dmg;
        isDead = PlayerStats.score < 0;
    }
}
