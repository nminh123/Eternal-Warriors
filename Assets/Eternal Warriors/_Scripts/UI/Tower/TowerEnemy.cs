using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : Tower
{
    [SerializeField] GameObject coint;
    public override void Damage(int damage)
    {
        base.Damage(damage);
        Instantiate(coint, this.transform.position, Quaternion.identity);
    }
}
