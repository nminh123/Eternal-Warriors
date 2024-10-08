using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowerEnemyBattleState : EntityState
{
    protected BowerEnemy bowerEnemy;
    public BowerEnemyBattleState(Entity entity, BowerEnemy bowerEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bowerEnemy = bowerEnemy;
    }

    public override void Enter()
    {
        base.Enter();

        bowerEnemy.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();

        if (bowerEnemy.CheckAttack())
        {
            if (bowerEnemy.CanAttack())
                stateMchine.ContinueState(bowerEnemy.attackState);
        }
        else
            stateMchine.ContinueState(bowerEnemy.moveState);
    }
}

