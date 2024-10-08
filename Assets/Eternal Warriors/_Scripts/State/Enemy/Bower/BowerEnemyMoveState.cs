using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowerEnemyMoveState : EntityState
{
    protected BowerEnemy bowerEnemy;
    public BowerEnemyMoveState(Entity entity, BowerEnemy bowerEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bowerEnemy = bowerEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();
        bowerEnemy.SetVelocity(bowerEnemy.speed);

        if (bowerEnemy.CheckAttack())
            stateMchine.ContinueState(bowerEnemy.battleState);
    }
}

