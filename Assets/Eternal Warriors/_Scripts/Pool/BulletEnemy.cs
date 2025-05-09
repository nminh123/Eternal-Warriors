using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    protected override void SetBullet()
    {
        rb.velocity = Vector2.left * speed;
    }

    protected override void TriggerAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, bulletDistance);

        foreach (Collider2D hit in colliders)
        {
            Ally ally = hit.GetComponent<Ally>();
            TowerAlly tower = hit.GetComponent<TowerAlly>();
            if (ally != null)
            {
                ally.Damage(damage);
                //SoundManager.instance.PlaySound("Arrow");
                ReturnToPool();
                break;
            }
            if (tower != null)
            {
                tower.Damage(damage);
                ReturnToPool();
                break;
            }
        }
    }
}
