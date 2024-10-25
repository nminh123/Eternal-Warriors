using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidniteOilSoftware.ObjectPoolManager;

public class TowerEnemy : Tower
{
    [SerializeField] GameObject coint;

    public bool islife = true;
    protected override void Start()
    {
        base.Start();
        islife = true;
    }
    public override void CheckDeah()
    {
        base.CheckDeah();
        if (health <= 0)
            islife = false;
        else
            islife = true;
    }
    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (damage <= 0) return;
        float positionXRamdom = Random.Range(-2f,1f);
        Vector3 positon = this.transform.position + new Vector3(positionXRamdom, this.transform.position.y);
        ObjectPoolManager.SpawnGameObject(coint, positon, Quaternion.identity);

    }
}
