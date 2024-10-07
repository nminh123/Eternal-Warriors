using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerAllyIdleState : EntityState
{
    protected BowerAlly bower;
    public BowerAllyIdleState(Entity entity, BowerAlly bower, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bower = bower;
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
    }
}
