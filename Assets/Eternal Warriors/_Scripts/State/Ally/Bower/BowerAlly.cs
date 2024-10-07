using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerAlly : Ally
{
    public BowerAllyIdleState idleState {  get; private set; }
    public BowerAllyMoveState moveState { get; private set; }
    public BowerAllyBattleState battleState { get; private set; }
    public BowerAllyAttackState attackState { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        battleState = new(this, this, stateMachine, "Idle");
        attackState = new(this, this, stateMachine, "Attack");
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
    public override void Damage(int Damge)
    {
        base.Damage(Damge);
    }
    protected override void CheckDeah()
    {
        base.CheckDeah();
    }
}
