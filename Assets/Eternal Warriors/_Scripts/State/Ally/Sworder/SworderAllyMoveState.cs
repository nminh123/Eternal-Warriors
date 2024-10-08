using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderAllyMoveState : EntityState
{
    protected SworderAlly sworderAlly;
    public SworderAllyMoveState(Entity entity, SworderAlly sworderAlly, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworderAlly = sworderAlly;
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

        sworderAlly.SetVelocity(sworderAlly.speed);
        if (sworderAlly.CheckAttack())
            stateMchine.ContinueState(sworderAlly.battleState);
    }
}

