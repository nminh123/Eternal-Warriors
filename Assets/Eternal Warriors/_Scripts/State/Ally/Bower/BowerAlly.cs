using System.Collections;
using System.Collections.Generic;
using Eternal_Warriors._Scripts;
using UnityEngine;

public class BowerAlly : Ally
{
    public BowerAllyIdleState idleState {  get; private set; }
    public BowerAllyMoveState moveState { get; private set; }
    public BowerAllyBattleState battleState { get; private set; }
    public BowerAllyAttackState attackState { get; private set; }
    public BowerAllyDeahState deahState { get; private set; }
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
        // maxHealth = GameManager.instance.ArrowHp;
        stateMachine.StartState(moveState);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        // maxHealth = GameManager.instance.ArrowHp;
        stateMachine.StartState(moveState);

    }
    protected override void Update()
    {
        base.Update();
    }

    protected override void AnimDeah()
    {
        base.AnimDeah();
        stateMachine.ContinueState(deahState);
    }
    protected override void AnimIdleTowerDeah()
    {
        base.AnimIdleTowerDeah();
        stateMachine.ContinueState(idleState);
    }

}
