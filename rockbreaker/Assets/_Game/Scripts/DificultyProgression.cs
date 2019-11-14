using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyProgression : MonoBehaviour
{
    public static int step = 1;

    public static bool CheckLevelUp(int level, int levelKills)
    {
        return levelKills >= level * step;
    }
    public static void LevelUp()
    {
        PlayerStats.LevelUp();
    }

}
