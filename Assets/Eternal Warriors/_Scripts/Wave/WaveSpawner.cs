using MidniteOilSoftware.ObjectPoolManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public GameObject[] enemyType;  
    public int[] enemyCount;    
    public float timeToNextWave;   
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenEnemies = 1f;
    public int currentWaveIndex = 0;
    public int waveNumber = 0;

    private void Start()
    {
        StartCoroutine(SpawnWavesCoroutine());
    }

    IEnumerator SpawnWavesCoroutine()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(2f);
            waveNumber++;
            yield return new WaitForSeconds(3f);
            Wave currentWave = waves[currentWaveIndex];

            // Spawn enemy theo wave
            for (int i = 0; i < currentWave.enemyType.Length; i++)
            {
                for (int j = 0; j < currentWave.enemyCount[i]; j++)
                {
                    SpawnEnemy(currentWave.enemyType[i]);
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }

            currentWaveIndex++;
            if (currentWaveIndex < waves.Length)
            {
                yield return new WaitForSeconds(currentWave.timeToNextWave);
            }
        }

    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        ObjectPoolManager.SpawnGameObject(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}