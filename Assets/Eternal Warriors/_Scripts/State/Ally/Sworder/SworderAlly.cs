﻿using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Eternal_Warriors._Scripts;
using UnityEngine;

public class SworderAlly : Ally
{
    public SworderAllyIdleState idleState {  get; private set; }
    public SworderAllyMoveState moveState { get; private set; }
    public SworderAllyBattleState battleState { get; private set; }
    public SworderAllyAttackState attackState { get; private set; }
    public SworderAllyDeahState deahState { get; private set; }

    public float distanceAttackk {  get; private set; }

    protected override void Awake()
    {
        base.Awake();
        distanceAttackk = attackDistance;
        distanceAttackk -= 0.2f;
        idleState = new(this, this, stateMachine, "Idle");
        moveState = new(this, this, stateMachine, "Move");
        battleState = new(this, this, stateMachine, "Idle");
        attackState = new(this, this, stateMachine, "Attack");
        deahState = new(this, this, stateMachine, "Deah");

    }
    protected override void OnEnable()
    {
        stateMachine.StartState(moveState);
        base.OnEnable();
        // damage = GameManager.instance.SwordPower;
        // maxHealth = GameManager.instance.SwordHp;
    }
    protected override void Start()
    {
        base.Start();

        // damage = GameManager.instance.SwordPower;
        // maxHealth = GameManager.instance.SwordHp;
        stateMachine.StartState(moveState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void AnimDeah()
    {
        stateMachine.ContinueState(deahState);
        //ReturnPool(this.gameObject);

    }
    protected override void AnimIdleTowerDeah()
    {
        base.AnimIdleTowerDeah();
        stateMachine.ContinueState(idleState);
    }
    //public override void SoundEffect()
    //{
    //    base.SoundEffect();
    //    SoundManager.instance.PlaySound("Sword");
    //}
}
