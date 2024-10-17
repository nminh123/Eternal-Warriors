using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderEnemyDeahState : EntityState
{
    protected SworderEnemy sworderEnemy;
    public SworderEnemyDeahState(Entity entity, SworderEnemy sworderEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworderEnemy = sworderEnemy;
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

        if (islife)
        {
            sworderEnemy.FallCoint();
            sworderEnemy.ReturnPool(sworderEnemy.gameObject);
        }
    }
}
