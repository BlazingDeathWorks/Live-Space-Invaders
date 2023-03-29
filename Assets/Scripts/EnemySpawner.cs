using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private PathData[] paths;
    private PathData currentWavePath;

    [SerializeField] private float waveSpawnRate = 6;
    private float lastWaveSpawned;

    [SerializeField] private float spawnRate;
    private float lastEnemySpawned;

    [SerializeField] private int enemiesPerWave;
    private int enemiesSpawned;

    private void Awake()
    {
        lastWaveSpawned = waveSpawnRate;
    }

    void Update()
    {
        if (paths.Length <= 0) return;

        lastWaveSpawned += Time.deltaTime;
        lastEnemySpawned += Time.deltaTime;

        //If time for the next wave or the current wave is still in progress
        if (lastWaveSpawned >= waveSpawnRate || enemiesSpawned > 0)
        {
            //If new wave is starting
            if (enemiesSpawned <= 0)
            {
                currentWavePath = paths[Random.Range(0, paths.Length)];
            }

            //If the wave has ended
            if (enemiesSpawned >= enemiesPerWave)
            {
                enemiesSpawned = 0;
                lastWaveSpawned -= waveSpawnRate;
                return;
            }

            //If time to spawn the next enemy in the wave
            if (lastEnemySpawned >= spawnRate)
            {
                enemiesSpawned++;
                Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.path = currentWavePath;
                lastEnemySpawned = 0;
            }
        }
    }
}
