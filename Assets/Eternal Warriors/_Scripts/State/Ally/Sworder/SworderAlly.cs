using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SworderAlly : Ally
{
    public SworderAllyIdleState idleState {  get; private set; }
    public SworderAllyMoveState moveState { get; private set; }
    public SworderAllyBattleState battleState { get; private set; }
    public SworderAllyAttackState attackState { get; private set; }
    public SworderAllyDeahState deahState { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        battleState = new(this, this, stateMachine, "Move");
        attackState = new(this, this, stateMachine, "Attack");
        deahState = new(this, this, stateMachine, "Deah");

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

    protected override void AnimDeah()
    {
        stateMachine.ContinueState(deahState);
    }
}
