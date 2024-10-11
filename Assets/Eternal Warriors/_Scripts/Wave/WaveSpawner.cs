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
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] wave;  
    public Transform spawnPoint;    
    public float timeBetweenEnemie = 1f; 
    public float timeBetweenWave = 5f;   

    private int currentWave = 0; 

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (currentWave < wave.Length) 
        {
            yield return new WaitForSeconds(timeBetweenWave); 

            Wave _currentWave = wave[currentWave]; 

            for (int i = 0; i < _currentWave.enemyType.Length; i++) 
            {
                for (int j = 0; j < _currentWave.enemyCount[i]; j++) 
                {
                    SpawnEnemy(_currentWave.enemyType[i]);
                    yield return new WaitForSeconds(timeBetweenEnemie); 
                }
            }

            currentWave++; 
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        ObjectPoolManager.SpawnGameObject(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
