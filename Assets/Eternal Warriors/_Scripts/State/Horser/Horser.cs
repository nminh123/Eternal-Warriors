using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Horser : Ally
{
    public HorserIdleState idleState { get; private set; }
    public HorserMoveState moveState { get; private set; }
    public HorserBattleState battleState { get; private set; }
    public HorserAttackState attackState { get; private set; }
    public HorserDeahState deahState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        attackState = new(this, this, stateMachine, "Attack");
        deahState = new(this, this, stateMachine, "Deah");
        battleState = new(this, this, stateMachine, "Idle");
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
    protected override void CheckDeah()
    {
        base.CheckDeah();
    }
    
}
