using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
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

    public static void LevelUp(float value)
    {
        if (value > 0.5f)
            PlayerStats.UpEnemyBaseMaxHp();
        else
            PlayerStats.UpEnemySpawnRate();
    }
}
