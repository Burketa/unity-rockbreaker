using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool destroyBulletsAfterKillingEnemy = false;
    private float speed = 1.0f;
    private int dmg = 1;
    private Vector3 targetPosition;
    private Transform player;

    private void Awake()
    {
        dmg = PlayerStats.dmg;
        speed = PlayerStats.bulletSpeed;

        player = GameObject.FindWithTag("Player").transform;

        GameObject.Destroy(gameObject, 2.0f);
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
            ParticleSystem particles = GameObject.Find("projetctile-particles").GetComponent<ParticleSystem>();
            particles.transform.position = transform.position;
            particles.Play();

            col.GetComponent<Enemy>().TakeDamage(dmg);

            Destroy(gameObject);
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
