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
            if (ally != null)
            {
                ally.Damage(damage);
                ReturnToPool();
                break;
            }
        }
    }
}
