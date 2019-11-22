using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private bool isDead = false;
    private int maxHp;
    private int hp;

    private Rigidbody2D _rgdbd;
    private Transform _egg;

    void Awake()
    {
        _egg = GameObject.FindWithTag("Egg").transform;
        _rgdbd = GetComponent<Rigidbody2D>();

        maxHp = PlayerStats.enemyBaseMaxHp;
        hp = maxHp;

        UpdateHp();
    }

    private void FixedUpdate()
    {
        //Limitar a velocidade
        LimitVelocity();
    }

    void Update()
    {
        if (isDead)
        {
            PlayerStats.AddScore(maxHp);
            PlayerStats.EnemyKill();
            SelfDestroy();
        }
        else
        {
            if (transform.position.y <= _egg.position.y)
            {
                Cannon.player.TakeDamage(hp);
                SelfDestroy();
            }
        }
    }

    public bool TakeDamage(int dmg)
    {
        hp -= dmg;
        hp = Mathf.Clamp(hp, 0, PlayerStats.enemyBaseMaxHp);
        UpdateHp();

        if (hp == 0)
        {
            isDead = true;
        }

        return isDead;
    }

    public void Die()
    {
        isDead = true;
    }

    public void UpdateHp()
    {
        GetComponentInChildren<Text>().text = hp.ToString();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public bool isEnemyDead()
    {
        return isDead;
    }

    public int getEnemyHp()
    {
        return hp;
    }

    private void LimitVelocity()
    {
        Vector2 vel = _rgdbd.velocity;
        vel.x = 0;
        vel.y = Mathf.Max(vel.y, -3.0f);
        _rgdbd.velocity = vel;
    }
}
