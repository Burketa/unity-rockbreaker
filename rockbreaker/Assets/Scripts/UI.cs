using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text score;
    public void Awake()
    {
        UpdateScore();
    }

    public void UpDamage()
    {
        PlayerStats.UpDamage();
    }
    public void UpFireRate()
    {
        PlayerStats.UpFireRate();
    }
    public void UpShotCount()
    {
        PlayerStats.UpShotCount();
    }
    public void UpEnemySpawnRate()
    {
        PlayerStats.UpEnemySpawnRate();
    }
    public void UpEnemyBaseMaxHp()
    {
        PlayerStats.UpEnemyBaseMaxHp();
    }

    public static void UpdateScore()
    {
        GameObject.FindWithTag("Score").GetComponent<Text>().text = PlayerStats.score.ToString();
        //score.text = PlayerStats.score.ToString();
    }
}
