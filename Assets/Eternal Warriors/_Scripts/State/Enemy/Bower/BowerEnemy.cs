using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerEnemy : Enemy
{
    public BowerEnemyIdleState idleState {  get; private set; }
    public BowerEnemyMoveState moveState { get; private set; }
    public BowerEnemyBattleState battleState { get; private set; }
    public BowerEnemyDeahState deahState { get; private set; }
    public BowerEnemyAtackState attackState { get; private set; }
    public override void Damage(int Damge)
    {
        base.Damage(Damge);
    }

    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        battleState = new(this, this, stateMachine, "Idle");
        attackState = new(this, this, stateMachine, "Attack");
    }

    protected override void CheckDeah()
    {
        base.CheckDeah();
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.StartState(moveState);
    }

    protected override void Update()
    {
        base.Update();
        
    }
}
