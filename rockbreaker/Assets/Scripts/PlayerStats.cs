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
        if (levelKills >= level * 10)
        {
            DificultyProgression.LevelUp();
            levelKills = 0;
        }
        else { levelKills++; }
    }
}