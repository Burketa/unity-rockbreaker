using UnityEngine;

public class PlayerStats
{
    public static int dmg = 1;
    public static int charges = 1;
    public static float fireRate = 1f;
    public static float enemySpawnRate = 1f;
    public static int enemyBaseMaxHp = 1;
    public static int bulletSpeed = 10;
    public static int level = 1;
    public static int totalKills = 0;
    public static int levelKills = 0;
    public static int score = 0;
    public static int upgrades = 1;
    /*
    */
    public static void Reset()
    {
        dmg = 1;
        charges = 1;
        fireRate = 1f;
        enemySpawnRate = 1f;
        enemyBaseMaxHp = 1;
        bulletSpeed = 10;
        level = 1;
        totalKills = 0;
        levelKills = 0;
        score = 0;
        upgrades = 1;
    }
    /* 
    public static void Reset()
    {
        dmg = 5;
        fireRate = 0.2f;
        charges = 5;
        enemySpawnRate = 0.1f;
        enemyBaseMaxHp = 8;
        bulletSpeed = 20;
        level = 1;
        totalKills = 0;
        levelKills = 0;
        score = 0;
        upgrades = 1;
    }
    */

    public static void UpDamage()
    {
        dmg++;
        upgrades--;
    }
    public static void UpFireRate()
    {
        fireRate *= 0.9f;
        upgrades--;
    }
    public static void UpCharges()
    {
        charges++;
        upgrades--;
    }
    public static void UpEnemySpawnRate()
    {
        enemySpawnRate = Random.value <= 0.2f ? enemySpawnRate * 0.8f : enemySpawnRate * 0.88f;
    }

    public static void UpEnemyBaseMaxHp()
    {
        enemyBaseMaxHp = Random.value <= 0.2f ? enemyBaseMaxHp + 4 : enemyBaseMaxHp + 2;
    }

    public static void AddScore(int val)
    {
        score += val;
        Utils.CheckHighscore(score);
    }

    public static void EnemyKill()
    {
        totalKills++;
        if (DifficultyProgression.CheckLevelUp(level, levelKills))
        {
            DifficultyProgression.LevelUp();
            levelKills = 0;
        }
        else { levelKills++; }
    }

    public static void LevelUp()
    {
        level++;
        upgrades++; //= randomValue <= 0.05f ? upgrades + 2 : upgrades + 1;
        bulletSpeed++;// = Random.value <= 0.05f ? bulletSpeed + 1 : bulletSpeed;
        bulletSpeed = Mathf.Min(PlayerStats.bulletSpeed, 20);

        if (Random.value < 0.5f)
        {
            UpEnemyBaseMaxHp();
            if (Random.value < 0.5f)
                UpEnemyBaseMaxHp();
        }
        else
        {
            UpEnemySpawnRate();
            if (Random.value < 0.4f)
                UpEnemySpawnRate();
        }
    }
}