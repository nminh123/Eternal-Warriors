using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAlly : Bullet
{
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
            if (enemy != null)
            {
                enemy.Damage(damage);
                ReturnToPool();
                break;
            }
        }
    }
}
