﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Entity : MonoBehaviour
{
    #region A
    protected EntityState entity { get; private set; }
    protected EntityStateMachine stateMachine { get; private set; }

    public Rigidbody2D rb { get;set; }
    public Animator animator { get;set; }
    public Collider2D col {  get; set; }
    #endregion
    [Header("Stat")]
    [SerializeField] protected int maxHealth;
    public float speed;
    public float attackCoolDown;
    public int facing;
    protected int currentHealth;
    protected bool islife = true;
    public float lastTimeAttacked { get;set;}
    [Header("Attack")]
    [SerializeField] protected Transform checkAttack;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected LayerMask whatIsCheckAttack;
    protected void OnEnable()
    {
        islife = true;
        currentHealth = maxHealth;

    }

    protected virtual void Awake()
    {
        stateMachine = new();
    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

        //currentHealth = maxHealth;
    }
    protected virtual void Update()
    {
        stateMachine.currentState.Logic();
        this.CheckDeah();
    }
    public virtual void SetVelocity(float x)
    {
        rb.velocity = new Vector2(x * facing, rb.velocity.y);
    }
    public virtual void SetZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }
    public void CheckAnimationAttack() => stateMachine.currentState.CheckAnimationAttack();
    public void CheckAnimationDeah() => stateMachine.currentState.CheckAnimationDeah();
    public RaycastHit2D CheckAttack() => Physics2D.Raycast(checkAttack.position, Vector2.right * facing, attackDistance, whatIsCheckAttack);

    public virtual void Damage(int Damge)
    {
        if (!islife) return;
        
        currentHealth -= Damge;
        
    }
    protected virtual void CheckDeah()
    {
        if(currentHealth <= 0 && islife)
        {
            col.enabled = false;
            islife = false;
            AnimDeah();
        }
    }
    protected virtual void AnimDeah() { }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(checkAttack.position, new Vector3
            (checkAttack.position.x + attackDistance * facing, checkAttack.position.y));
    }
    public bool CanAttack()
    {
        if (Time.time >= lastTimeAttacked + attackCoolDown)
        {
            lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }

    public void ReturnToPool()
    {
        GameObject.FindObjectOfType<PoolTest>().ReturnObject(gameObject);
        col.enabled = true;
    }
}
