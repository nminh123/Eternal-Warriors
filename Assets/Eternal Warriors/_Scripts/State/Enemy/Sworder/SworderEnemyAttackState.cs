using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderEnemyAttackState : EntityState
{
    protected SworderEnemy sworder;
    public SworderEnemyAttackState(Entity entity, SworderEnemy sworder, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        if (isCalled)
            stateMchine.ContinueState(sworder.battleState);

    }
}
