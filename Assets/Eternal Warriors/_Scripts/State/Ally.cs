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
            if (enemy != null)
            {
                enemy.Damage(1);
                break;
            }
        }
    }
}
