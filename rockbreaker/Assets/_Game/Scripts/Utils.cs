using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{
    public Transform bulletsParent;

    private void Update()
    {
        if (bulletsParent.childCount >= PlayerStats.shotCount * 5)
            Explode();
    }

    public static bool CheckTimer(float current, float cooldown)
    {
        return current >= cooldown;
    }

    public static bool isEnemiesPresent()
    {
        try
        {
            return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
        }
        catch (NullReferenceException exp)
        {
            return false;
        }
    }
    public static GameObject[] PossibleEnemies()
    {
        try
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            return enemies.Length > 0 ? enemies : null;
        }
        catch (NullReferenceException exp)
        {
            Debug.Log("Sem inimigos spawnados.");
            return null;
        }
    }

    public static void CheckHighscore(int score)
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if (score > highscore)
        {
            int newHighscore = score;
            PlayerPrefs.SetInt("highscore", newHighscore);
            PlayerPrefs.Save();
        }
    }

    public static void RestartLevel()
    {
        PlayerStats.Reset();
        SceneManager.LoadScene(0);
    }

    private void Explode()
    {
        foreach (Transform child in bulletsParent)
        {
            try
            {
                child.GetComponent<Projectile>().SelfDestroy();
            }
            catch (Exception exp) { }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies[0].GetComponent<Enemy>().TakeDamage(PlayerStats.dmg);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(PlayerStats.dmg / 5);
        }

        GameObject.Find("big-particles").GetComponent<ParticleSystem>().Play();
    }
}
