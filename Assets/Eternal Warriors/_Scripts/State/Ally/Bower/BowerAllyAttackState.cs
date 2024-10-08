using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerAllyAttackState : EntityState
{
    protected BowerAlly bower;
    public BowerAllyAttackState(Entity entity, BowerAlly bower, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        if(isCalled)
            stateMchine.ContinueState(bower.battleState);
    }
}
