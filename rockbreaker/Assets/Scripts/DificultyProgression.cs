using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyProgression : MonoBehaviour
{
    public static void LevelUp()
    {
        PlayerStats.level++;
        PlayerStats.upgrades++;
        if (UnityEngine.Random.value > 0.5f)
            PlayerStats.UpEnemyBaseMaxHp();
        else
            PlayerStats.UpEnemySpawnRate();
    }
}
