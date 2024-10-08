using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerTest : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform spwanerPoint;

    public void Spawner(int index)
    {
        ObjectPoolManager.SpawnGameObject(prefab[index], spwanerPoint.transform.position, Quaternion.identity);
    }
}
