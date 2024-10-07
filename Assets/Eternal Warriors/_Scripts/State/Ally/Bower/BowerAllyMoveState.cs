using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowerAllyMoveState : EntityState
{
    protected BowerAlly bower;
    public BowerAllyMoveState(Entity entity, BowerAlly bower, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        bower.SetVelocity(bower.speed);

        if(bower.CheckAttack())
            stateMchine.ContinueState(bower.battleState);
    }
}
