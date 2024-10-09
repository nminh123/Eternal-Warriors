using MidniteOilSoftware.ObjectPoolManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemyTypes; 
        public int[] enemyCounts;       
    }

    public Wave[] waves;  
    public Transform spawnPoint;    
    public float timeBetweenEnemies = 1f; 
    public float timeBetweenWaves = 5f;   

    private int currentWaveIndex = 0; 

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length) 
        {
            yield return new WaitForSeconds(timeBetweenWaves); 

            Debug.Log("Wave " + (currentWaveIndex + 1) + " started!");

            Wave currentWave = waves[currentWaveIndex]; 

            for (int i = 0; i < currentWave.enemyTypes.Length; i++) 
            {
                for (int j = 0; j < currentWave.enemyCounts[i]; j++) 
                {
                    SpawnEnemy(currentWave.enemyTypes[i]);
                    yield return new WaitForSeconds(timeBetweenEnemies); 
                }
            }

            currentWaveIndex++; 
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        ObjectPoolManager.SpawnGameObject(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
