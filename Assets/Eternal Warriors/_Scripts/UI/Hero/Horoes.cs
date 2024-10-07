using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horoes : MonoBehaviour
{
    public GameObject[] heroes;
    public Transform spawnPoint;

    public void HeroesSpawn(int Index)
    {
        Instantiate(heroes[Index], spawnPoint.position, Quaternion.identity);
    }
}
