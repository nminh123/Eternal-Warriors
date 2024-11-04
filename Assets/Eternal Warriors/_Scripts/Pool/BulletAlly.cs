using System.Collections;
using System.Collections.Generic;
using Eternal_Warriors._Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class BulletAlly : Bullet
{
    protected override void OnEnable()
    {
        base.OnEnable();
        // damage = GameManager.instance.ArrowPower;
    }

    protected override void Start()
    {
        base.Start();
        // damage = GameManager.instance.ArrowPower;
    }

    protected override void SetBullet()
    {
        rb.velocity = Vector2.right * speed;
    }

    protected override void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, bulletDistance);

        foreach (Collider2D hit in colliders)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            TowerEnemy tower = hit.GetComponent<TowerEnemy>();
            if (enemy != null)
            {
                enemy.Damage(damage);
                //SoundManager.instance.PlaySound("Arrow");
                ReturnToPool();
                break;
            }
            if(tower != null)
            {
                tower.Damage(damage);
                ReturnToPool();
                break;
            }
        }
    }
}
