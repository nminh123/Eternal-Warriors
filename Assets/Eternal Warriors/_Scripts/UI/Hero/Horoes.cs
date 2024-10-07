using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horoes : MonoBehaviour
{
    public GameObject[] heroes;
    public Transform spawnPoint;

    public void HeroesSpawn(int Index)
    {
        if(Power.instance.power <= 0) return;
        if (heroes[0] && Power.instance.power >= 2)
        {
            Power.instance.RomovePower(2);
            Instantiate(heroes[0], spawnPoint.position, Quaternion.identity);
        }
    }
}
