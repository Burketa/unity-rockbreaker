using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool destroyBulletsAfterKillingEnemy = false;
    private float speed = 1.0f;
    private int dmg = 1;
    private Vector3 targetPosition;
    private Transform player;
    private ParticleSystem particles;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        particles = GameObject.Find("projetctile-particles").GetComponent<ParticleSystem>();

        dmg = PlayerStats.dmg;
        speed = PlayerStats.bulletSpeed;
    }

    void Update()
    {
        dmg = PlayerStats.dmg;
        FollowTarget();
    }

    private void FollowTarget()
    {
        try
        {
            foreach (GameObject enemy in Utils.PossibleEnemies())
            {
                if (enemy.transform.position.y > player.position.y)
                {
                    targetPosition = enemy.transform.position;
                    break;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.right = targetPosition - transform.position;
        }
        catch (NullReferenceException exp)
        {
            if (destroyBulletsAfterKillingEnemy)
                Destroy(gameObject);
            else
                Debug.Log("Ops, sem inimigos para essa bullet.");

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            particles.transform.position = transform.position;
            particles.Play();

            Enemy enemy = col.GetComponent<Enemy>();
            if (!enemy.isEnemyDead())
            {
                enemy.TakeDamage(dmg);
                Destroy(gameObject);
            }
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
