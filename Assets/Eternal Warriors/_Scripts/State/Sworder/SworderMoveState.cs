using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderMoveState : EntityState
{
    protected Sworder sworder;
    public SworderMoveState(Entity entity, Sworder sworder, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworder = sworder;
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

        sworder.SetVelocity(sworder.speed);
        if (sworder.CheckAttack())
            stateMchine.ContinueState(sworder.battleState);
    }
}
