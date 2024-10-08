using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserEnemyDeahState : EntityState
{
    private HorserEnemy horserEnemy;
    public HorserEnemyDeahState(Entity entity, HorserEnemy horserEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.horserEnemy = horserEnemy;
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

