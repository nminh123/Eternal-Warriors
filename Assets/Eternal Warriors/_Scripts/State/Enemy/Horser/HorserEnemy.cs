using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserEnemy : Enemy
{
    public HorserEnemyIdleState idleState {  get; private set; }
    public HorserEnemyMoveState moveState { get; private set; }
    public HorserEnemyBattleState battleState { get; private set; }
    public HorserEnemyAttackState attackState { get; private set; }
    public HorserEnemyDeahState deahState { get; private set; }
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
        //SoundManager.instance.PlaySound("Hourse");

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
        base.AnimDeah();
        stateMachine.ContinueState(deahState);

    }
    protected override void AnimIdleTowerDeah()
    {
        stateMachine.ContinueState(idleState);
    }
    public override void SoundEffect()
    {
        base.SoundEffect();
        //SoundManager.instance.PlaySound("Sword2");
    }
}
