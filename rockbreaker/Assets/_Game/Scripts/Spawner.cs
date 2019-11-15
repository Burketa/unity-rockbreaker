using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnCooldown;
    private float currentSpawnTimer;

    private void Awake()
    {
        spawnCooldown = PlayerStats.enemySpawnRate;
    }
    private void Update()
    {
        spawnCooldown = PlayerStats.enemySpawnRate;
        CheckIfCanSpawn();
    }

    private void CheckIfCanSpawn()
    {
        if (Utils.CheckTimer(currentSpawnTimer, spawnCooldown) || !Utils.isEnemiesPresent())
        {
            Spawn();
            currentSpawnTimer = 0;
        }
        else
        {
            currentSpawnTimer += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Transform spawnPoint = transform.GetChild(Random.Range(0, transform.transform.childCount));
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
