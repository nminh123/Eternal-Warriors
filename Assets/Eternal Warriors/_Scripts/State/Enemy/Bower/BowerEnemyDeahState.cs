using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerEnemyDeahState : EntityState
{
    protected BowerEnemy bowerEnemy;
    public BowerEnemyDeahState(Entity entity, BowerEnemy bowerEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bowerEnemy = bowerEnemy;
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
            bowerEnemy.ReturnPool(bowerEnemy.gameObject);
    }
}
