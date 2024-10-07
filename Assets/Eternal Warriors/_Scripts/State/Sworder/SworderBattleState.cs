using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderBattleState : EntityState
{
    protected Sworder sworder;
    public SworderBattleState(Entity entity, Sworder sworder, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworder = sworder;
    }

    public override void Enter()
    {
        base.Enter();
        sworder.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();

        if (sworder.CheckAttack())
        {
            if (sworder.CanAttack())
                stateMchine.ContinueState(sworder.attackState);
        }
        else
            stateMchine.ContinueState(sworder.moveState);
    }
}
