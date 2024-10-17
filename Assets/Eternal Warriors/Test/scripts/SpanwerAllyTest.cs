using MidniteOilSoftware.ObjectPoolManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerAllyTest : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform spwanerPoint;
    protected Tower tower {  get;set; }

    private void Start()
    {
        tower = FindObjectOfType<Tower>();
    }
    public void Spawner(int index)
    {
        if(!tower.isLive) return;
        if (Power.instance.power <= 0) return;
        if (index == 0 && Power.instance.power >= 3)
        {
            Power.instance.RomovePower(3);
            Heroes(index);
        }
        else if (index == 1 && Power.instance.power >= 6)
        {
            Power.instance.RomovePower(6);
            Heroes(index);
        }
        else if (index == 2 && Power.instance.power >= 9)
        {
            Power.instance.RomovePower(9);
            Heroes(index);
        }
    }
    public void Heroes(int index)
    {
        ObjectPoolManager.SpawnGameObject(prefab[index], spwanerPoint.transform.position, Quaternion.identity);
    }
}
