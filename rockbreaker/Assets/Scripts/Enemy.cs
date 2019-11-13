using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int maxHp;
    private int hp;
    private bool isAlive = true;

    void Awake()
    {
        maxHp = PlayerStats.enemyBaseMaxHp;
        hp = maxHp;

        UpdateHp();

        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        if (!isAlive && gameObject != null)
        {
            PlayerStats.AddScore(maxHp);
            UI.UpdateScore();
            Destroy(gameObject);
        }
    }

    public bool TakeDamage(int dmg)
    {
        hp -= dmg;
        hp = Mathf.Clamp(hp, 0, 10);
        UpdateHp();

        if (hp == 0)
        {
            isAlive = false;
        }

        return isAlive;
    }

    public void UpdateHp()
    {
        GetComponentInChildren<Text>().text = hp.ToString();
    }
}
