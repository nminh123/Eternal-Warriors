using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BowerEnemyAtackState : EntityState
{
    protected BowerEnemy bowerEnemy;
    public BowerEnemyAtackState(Entity entity, BowerEnemy bowerEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        if (isCalled)
            stateMchine.ContinueState(bowerEnemy.battleState);
    }
}
