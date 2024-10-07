using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerAllyBattleState : EntityState
{
    protected BowerAlly bower;
    public BowerAllyBattleState(Entity entity, BowerAlly bower, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bower = bower;
    }

    public override void Enter()
    {
        base.Enter();

        bower.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();

        if (bower.CheckAttack())
        {
            if (bower.CanAttack())
                stateMchine.ContinueState(bower.attackState);
        }
        else
            stateMchine.ContinueState(bower.moveState);
    }
}
