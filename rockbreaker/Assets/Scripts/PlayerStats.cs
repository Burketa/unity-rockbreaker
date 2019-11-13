using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PlayerStats
{
    public static int dmg = 1;
    public static float fireRate = 1f;
    public static int shotCount = 1;
    public static float enemySpawnRate = 1f;
    public static int enemyBaseMaxHp = 1;
    public static float bulletSpeed = 10f;
    public static int score = 0;

    public static void UpDamage()
    {
        dmg++;
    }
    public static void UpFireRate()
    {
        fireRate *= 0.9f;
    }
    public static void UpShotCount()
    {
        shotCount++;
    }
    public static void UpEnemySpawnRate()
    {
        enemySpawnRate *= 0.9f;
    }

    public static void UpEnemyBaseMaxHp()
    {
        enemyBaseMaxHp++;
    }

    public static void AddScore(int val)
    {
        score += val;
    }
}