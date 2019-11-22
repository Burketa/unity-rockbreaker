using System;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public bool destroyBulletsAfterKillingEnemy = false;
    private float speed = 1.0f;
    private int charges = 1;
    private int dmg = 1;
    private Vector3 targetPosition;
    private Transform player;
    private ParticleSystem particles;
    private RectTransform canvasRectTransform;
    private Text chargesText;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        particles = GameObject.Find("projetctile-particles").GetComponent<ParticleSystem>();
        canvasRectTransform = transform.GetChild(0).transform.GetComponent<RectTransform>();
        chargesText = transform.GetComponentInChildren<Text>();

        dmg = PlayerStats.dmg;
        speed = PlayerStats.bulletSpeed;
        charges = PlayerStats.charges;

        UpdateCharges();
    }

    void Update()
    {
        if (charges <= 0)
            Destroy(gameObject);

        FollowTarget();

        canvasRectTransform.rotation = Quaternion.Euler(0, 0, -transform.rotation.z);
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

            int totalDamage = dmg * charges;
            int enemyHp = enemy.getEnemyHp();

            if (totalDamage >= enemyHp)
            {
                enemy.Die();
                charges = (totalDamage - enemyHp) / dmg;
                UpdateCharges();
            }
            else
            {
                enemy.TakeDamage(totalDamage);
                Destroy(gameObject);
            }
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    private void UpdateCharges()
    {
        chargesText.text = charges.ToString();
    }
}
