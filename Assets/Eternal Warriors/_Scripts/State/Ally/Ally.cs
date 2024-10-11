using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Entity
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkAttack.position, attackDistance);

        foreach (Collider2D hit in colliders)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            TowerEnemy tower = hit.GetComponent<TowerEnemy>();
            if (enemy != null)
            {
                enemy.Damage(damage);
                break;
            }
            else if(tower != null)
            {
                tower.Damage(damage/2);
                break;
            }
        }
    }
}
