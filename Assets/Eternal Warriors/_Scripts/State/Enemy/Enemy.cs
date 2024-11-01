using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : Entity
{
    public GameObject Coint;
    public QuestType enemyType;
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
    protected override void CheckTowerDeah(GameObject obj)
    {
        base.CheckTowerDeah(obj);

    }
    public override void Damage(int Damge)
    {
        base.Damage(Damge);
    }
    protected override void AnimDeah()
    {
        base.AnimDeah();
        QuestManager.instance.UpdateQuest(enemyType, 1);
    }
    public virtual void FallCoint()
    {
        //ObjectPoolManager.SpawnGameObject(Coint, this.transform.position, Quaternion.identity);
        if (Coint != null)
        {
            ObjectPoolManager.SpawnGameObject(Coint, this.transform.position, Quaternion.identity);
        }
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
                SoundEffect();
                break;
            }
            else if(tower != null)
            {
                tower.Damage(damage);
                SoundManager.instance.PlaySound("Sword");
                break;
            }
        }
    }
    public virtual void SoundEffect()
    {

    }
}
