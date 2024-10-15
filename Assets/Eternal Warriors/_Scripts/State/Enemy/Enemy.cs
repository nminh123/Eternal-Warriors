using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public GameObject Coint;
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
    public override void Damage(int Damge)
    {
        base.Damage(Damge);
    }
    public virtual void FallCoint()
    {
        Instantiate(Coint, this.transform.position,Quaternion.identity);
    }
    protected void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkAttack.position, attackDistance);

        foreach (Collider2D hit in colliders)
        {
            Ally ally = hit.GetComponent<Ally>();
            TowerAlly tower = hit.GetComponent<TowerAlly>();
            if (ally != null)
            {
                ally.Damage(damage);
                break;
            }
            else if(tower != null)
            {
                tower.Damage(damage);
                break;
            }
        }
    }
}
