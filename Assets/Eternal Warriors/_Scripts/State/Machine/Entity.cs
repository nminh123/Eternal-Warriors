using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Entity : MonoBehaviour
{
    protected EntityState entity { get; private set; }
    protected EntityStateMachine stateMachine { get; private set; }

    protected Rigidbody2D rb { get;set; }
    protected Animator animator { get;set; }
    [Header("Stat")]
    [SerializeField]  protected float speed;
    [SerializeField] protected int maxHealth;
    protected int currentHealth;
    protected bool islife = true;
    [Header("Attack")]
    [SerializeField] protected Transform checkAttack;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected LayerMask whatIsCheckAttack;
    [SerializeField]
    protected int facing;
    protected virtual void Awake()
    {
        stateMachine = new();
    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }
    protected virtual void Update()
    {
        stateMachine.currentState.Logic();
    }
    protected virtual void SetVelocity()
    {
        rb.velocity = new Vector2(speed * facing,rb.velocity.y);
    }
    protected virtual void SetZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }
    public RaycastHit2D CheckPlayer() => Physics2D.Raycast(checkAttack.position, Vector2.right * facing, attackDistance, whatIsCheckAttack);

    protected virtual void Damge(int Damge)
    {
        if(islife)
            currentHealth -= Damge;
    }
    protected virtual void CheckDeah()
    {
        if(maxHealth <= 0)
            islife = false;
    }
}
