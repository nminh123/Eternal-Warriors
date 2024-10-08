using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    protected Rigidbody2D rb;
    protected int facing = 1;
    protected float bulletDistance;
    protected float lifetime = 4f;
    protected float lifeTimer;

    protected void OnEnable()
    {
        lifeTimer = 0f;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        SetBullet();
        CoutDownBullet();
        TriggerAttack();
    }
    protected void CoutDownBullet()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
        {
            ReturnToPool();
        }
    }
    protected virtual void SetBullet()
    {
        
    }
    protected void ReturnToPool()
    {
        GameObject.FindObjectOfType<PoolObject>().ReturnObject(gameObject);
    }
    protected virtual void TriggerAttack()
    {
        
    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, new Vector3
            (this.transform.position.x + bulletDistance * facing, this.transform.position.y));
    }
}
