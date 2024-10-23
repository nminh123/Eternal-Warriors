using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderEnemy : Enemy
{
    public SworderEnemyIdleState idleState {  get; private set; }
    public SworderEnemyMoveState moveState { get; private set; }
    public SworderEnemyBattleState battleState { get; private set; }
    public SworderEnemyAttackState attackState { get; private set; }
    public SworderEnemyDeahState deahState {  get; private set; }
    protected override void Awake()
    {
        base.Awake();
        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        battleState = new(this, this, stateMachine, "Idle");
        attackState = new(this, this, stateMachine, "Attack");
        deahState = new(this, this, stateMachine, "Deah");

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.StartState(moveState);
    }
    protected override void OnEnable()
    {
        stateMachine.StartState(moveState);
        base.OnEnable();

    }
    protected override void Update()
    {
        base.Update();
    }

    public override void Damage(int Damge)
    {
        base.Damage(Damge);
    }
    protected override void AnimDeah()
    {
        stateMachine.ContinueState(deahState);
    }
    protected override void AnimIdleTowerDeah()
    {
        stateMachine.ContinueState(idleState);
    }
}
