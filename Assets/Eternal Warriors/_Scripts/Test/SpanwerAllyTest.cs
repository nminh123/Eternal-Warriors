using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerAllyTest : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform spwanerPoint;

    public void Spawner(int index)
    {
        if (Power.instance.power <= 0) return;
        if (index == 0 && Power.instance.power >= 2)
            Power.instance.RomovePower(2);
        else if(index == 2 && Power.instance.power >= 2)
            Power.instance.RomovePower(2);
        else if(index == 3 && Power.instance.power >= 2)
            Power.instance.RomovePower(2);

        ObjectPoolManager.SpawnGameObject(prefab[index], spwanerPoint.transform.position, Quaternion.identity);

    }
}
