﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorserAlly : Ally
{
    public HorserAllyIdleState idleState { get; private set; }
    public HorserAllyMoveState moveState { get; private set; }
    public HorserAllyBattleState battleState { get; private set; }
    public HorserAllyAttackState attackState { get; private set; }
    public HorserAllyDeahState deahState { get; private set; }
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
    protected override void OnEnable()
    {
        stateMachine.StartState(moveState);
        base.OnEnable();
        SoundManager.instance.PlaySound("Elephant");

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
    public override void SoundEffect()
    {
        base.SoundEffect();
        SoundManager.instance.PlaySound("Sword");
    }
}
