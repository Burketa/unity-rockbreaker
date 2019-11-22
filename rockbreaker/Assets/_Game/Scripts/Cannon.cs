using System;
using UnityEngine;
using EZCameraShake;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletsParent;
    public Transform bulletShootPoint;
    public Transform cannonBody;

    private float shotCooldown;
    private float currentShotTimer;
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponentInChildren<Animation>();

        PlayerStats.Reset();

        shotCooldown = PlayerStats.fireRate;
        currentShotTimer = shotCooldown;
    }

    void Update()
    {
        shotCooldown = PlayerStats.fireRate;
        Aim();
        CheckIfCanShoot();
    }

    private void Aim()
    {
        GameObject[] possibleEnemies = Utils.PossibleEnemies();
        if (possibleEnemies != null && possibleEnemies.Length > 0)
            foreach (GameObject enemy in possibleEnemies)
            {
                if (isValidEnemy(enemy))
                {
                    AimAt(enemy);
                    break;
                }
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
                if (isValidEnemy(enemy))
                {
                    DoShoot();
                    break;
                }
            }
        }
        catch (NullReferenceException exp) { Debug.Log("Ops, sem inimigos para atirar"); }
    }

    private void AimAt(GameObject enemy)
    {
        //Gira o corpo do canhão para o alvo
        if (transform.localScale.y < 0)

            cannonBody.transform.up = -1 * (enemy.transform.position - transform.position);
        else
            cannonBody.transform.up = enemy.transform.position - transform.position;
    }

    private void DoShoot()
    {
        _animation.Play("player-shoot-plant");

        GameObject shot = GameObject.Instantiate(bulletPrefab, bulletShootPoint.position, Quaternion.identity, bulletsParent);
    }

    private bool isValidEnemy(GameObject enemy)
    {
        return enemy.transform.position.y > transform.position.y;
    }
}
