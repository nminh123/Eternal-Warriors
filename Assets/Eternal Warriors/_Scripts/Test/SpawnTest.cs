using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public PoolTest poolTest;  // Reference to PoolTest
    public Transform spawnPoint;

    public void TrieuHoiHeroes(int index)  // Fixed typo and improved logic
    {
        GameObject hero = poolTest.GetObject(index);  // Use index to choose specific hero type
        hero.transform.position = spawnPoint.position;
        hero.transform.rotation = spawnPoint.rotation;
    }
}
