using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderAllyAttackState : EntityState
{
    protected SworderAlly sworderAlly;
    public SworderAllyAttackState(Entity entity, SworderAlly sworderAlly, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworderAlly = sworderAlly;
    }

    public override void Enter()
    {
        base.Enter();
        sworderAlly.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();

        if (isCalled)
            stateMchine.ContinueState(sworderAlly.battleState);
    }
}
