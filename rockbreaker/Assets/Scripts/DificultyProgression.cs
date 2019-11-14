using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyProgression : MonoBehaviour
{
    public static int step = 1;
    public static void LevelUp()
    {
        PlayerStats.level++;
        PlayerStats.upgrades++;
        PlayerStats.bulletSpeed++;
        PlayerStats.bulletSpeed = Mathf.Min(PlayerStats.bulletSpeed, 20);

        float randomValue = Random.value;
        if (randomValue <= 0.05f)
            PlayerStats.upgrades++;

        else if (randomValue >= 0.9f)
        {
            PlayerStats.UpEnemyBaseMaxHp();
            PlayerStats.UpEnemySpawnRate();
        }

        if (randomValue > 0.5f)
            PlayerStats.UpEnemyBaseMaxHp();
        else
            PlayerStats.UpEnemySpawnRate();
    }

    public static bool CheckLevelUp(int level, int levelKills)
    {
        return levelKills >= level * step;
    }
}
