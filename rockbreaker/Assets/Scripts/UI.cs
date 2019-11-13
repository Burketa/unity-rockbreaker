using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text level;
    public Text levelKills;
    public Text totalKills;
    public Text score;

    public void Awake()
    {
        UpdateAll();
    }

    public void Update()
    {
        UnlockButtons(PlayerStats.upgrades > 0);
        UpdateAll();
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

    public void UpdateAll()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateShootCount();
        UpdateUpgrades();
        UpdateLevel();
        UpdateLevelKills();
        UpdateTotalKills();
        UpdateScore();
        UpdateHighscore();
    }
    public static void UpdateDamage()
    {
        GameObject.Find("button-dmg").transform.GetChild(0).GetComponent<Text>().text = PlayerStats.dmg.ToString();
    }
    public static void UpdateSpeed()
    {
        GameObject.Find("button-firerate").transform.GetChild(0).GetComponent<Text>().text = PlayerStats.fireRate.ToString();
    }
    public static void UpdateShootCount()
    {
        GameObject.Find("button-shots").transform.GetChild(0).GetComponent<Text>().text = PlayerStats.shotCount.ToString();
    }
    public static void UpdateUpgrades()
    {
        GameObject.Find("upgrades").transform.GetChild(1).GetComponent<Text>().text = PlayerStats.upgrades.ToString();
    }
    public static void UpdateLevel()
    {
        GameObject.Find("level").transform.GetChild(1).GetComponent<Text>().text = PlayerStats.level.ToString();
    }

    public static void UpdateLevelKills()
    {
        GameObject.Find("level-kills").transform.GetChild(1).GetComponent<Text>().text = PlayerStats.levelKills.ToString();
    }

    public static void UpdateTotalKills()
    {
        GameObject.Find("kills-total").transform.GetChild(1).GetComponent<Text>().text = PlayerStats.totalKills.ToString();
    }

    public static void UpdateScore()
    {
        GameObject.Find("score").transform.GetChild(1).GetComponent<Text>().text = PlayerStats.score.ToString();
        //score.text = PlayerStats.score.ToString();
    }
    public static void UpdateHighscore()
    {
        GameObject.Find("highscore").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore", 0).ToString();
        //score.text = PlayerStats.score.ToString();
    }

    public void UnlockButtons(bool state)
    {
        GameObject.Find("upgrades").GetComponent<Button>().interactable = state;

        Button[] buttons = GameObject.Find("buttons").GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }
    }
}
