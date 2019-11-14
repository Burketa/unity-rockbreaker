public class PlayerStats
{
    public static int dmg = 1;
    public static float fireRate = 1f;
    public static int shotCount = 1;
    public static float enemySpawnRate = 1f;
    public static int enemyBaseMaxHp = 1;
    public static int bulletSpeed = 10;
    public static int level = 1;
    public static int totalKills = 0;
    public static int levelKills = 0;
    public static int score = 0;
    public static int upgrades = 1;

    public static void Reset()
    {
        dmg = 1;
        fireRate = 1f;
        shotCount = 1;
        enemySpawnRate = 1f;
        enemyBaseMaxHp = 1;
        bulletSpeed = 10;
        level = 1;
        totalKills = 0;
        levelKills = 0;
        score = 0;
        upgrades = 1;
    }
    /*public static void Reset()
    {
        dmg = 5;
        fireRate = 0.2f;
        shotCount = 5;
        enemySpawnRate = 0.1f;
        enemyBaseMaxHp = 8;
        bulletSpeed = 20;
        level = 1;
        totalKills = 0;
        levelKills = 0;
        score = 0;
        upgrades = 1;
    }*/

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
    public static void UpShotCount()
    {
        shotCount++;
        upgrades--;
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
        Utils.CheckHighscore(score);
    }

    public static void EnemyKill()
    {
        totalKills++;
        if (DificultyProgression.CheckLevelUp(level, levelKills))
        {
            DificultyProgression.LevelUp();
            levelKills = 0;
        }
        else { levelKills++; }
    }

    public static void LevelUp()
    {
        level++;
        upgrades = UnityEngine.Random.value <= 0.2f ? upgrades + 1 : upgrades + 2;
        bulletSpeed = UnityEngine.Mathf.Min(PlayerStats.bulletSpeed, 20);
        if (UnityEngine.Random.value > 0.5f)
            UpEnemyBaseMaxHp();
        else
            UpEnemySpawnRate();
    }
}