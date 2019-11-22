using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //Highscore
    public Text highscore;

    //Upgrades
    public Text dmg;
    public Text speed;
    public Text charges;

    //Stats
    public Button upgradesButton;
    public Text upgradesText;
    public Text level;
    public Text levelKills;
    public Text totalKills;
    public Text score;

    //Buttons
    public Transform buttonsTransform;

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
        PlayerStats.UpCharges();
    }

    public void UpdateAll()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateCharges();
        UpdateUpgrades();
        UpdateLevel();
        UpdateLevelKills();
        UpdateTotalKills();
        UpdateScore();
        UpdateHighscore();
    }
    public void UpdateDamage()
    {
        dmg.text = PlayerStats.dmg.ToString();
    }
    public void UpdateSpeed()
    {
        speed.text = $"{PlayerStats.fireRate.ToString("0.00")}s";
    }
    public void UpdateCharges()
    {
        charges.text = PlayerStats.charges.ToString();
    }
    public void UpdateUpgrades()
    {
        upgradesText.text = PlayerStats.upgrades.ToString();
    }
    public void UpdateLevel()
    {
        level.text = PlayerStats.level.ToString();
    }

    public void UpdateLevelKills()
    {
        levelKills.text = PlayerStats.levelKills.ToString();
    }

    public void UpdateTotalKills()
    {
        totalKills.text = PlayerStats.totalKills.ToString();
    }

    public void UpdateScore()
    {
        score.text = PlayerStats.score.ToString();
    }
    public void UpdateHighscore()
    {
        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void UnlockButtons(bool state)
    {
        upgradesButton.GetComponent<Button>().interactable = state;

        Button[] buttons = buttonsTransform.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = state;
        }
    }
}
