using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidniteOilSoftware.ObjectPoolManager;

public class TowerEnemy : Tower
{
    [SerializeField] GameObject coint;
    public override void Damage(int damage)
    {
        base.Damage(damage);
        float positionXRamdom = Random.Range(-2f,1f);
        Vector3 positon = this.transform.position + new Vector3(positionXRamdom, this.transform.position.y);
        ObjectPoolManager.SpawnGameObject(coint, positon, Quaternion.identity);

    }
}
