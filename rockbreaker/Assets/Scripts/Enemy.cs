using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int maxHp;
    private int hp;
    private bool isDead = false;

    void Awake()
    {
        maxHp = PlayerStats.enemyBaseMaxHp;
        hp = maxHp;

        UpdateHp();

        Destroy(gameObject, 3.0f);
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
            if (transform.position.y <= Player.player.transform.position.y)
            {
                Player.player.TakeDamage(hp);
                SelfDestroy();
                //Efeito de Camera shake ?
                //Particulas ?
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

    public void UpdateHp()
    {
        GetComponentInChildren<Text>().text = hp.ToString();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
