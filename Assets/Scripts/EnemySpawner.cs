using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    float lastSpawned;

    public int enemiesPerWave;
    public int enemiesSpawned;

    Vector2 spawnPos;
    public GameObject EnemyPrefab;

    private void Awake()
    {
        //can be changed
        spawnPos = transform.position;
    }

    void Update()
    {
        lastSpawned += Time.deltaTime;
        if (lastSpawned > spawnRate/60 && enemiesSpawned < enemiesPerWave)
        {
            enemiesSpawned++;
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
            lastSpawned = 0;
        }
    }
}
