using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserEnemyBattleState : EntityState
{
    private HorserEnemy horserEnemy;
    public HorserEnemyBattleState(Entity entity, HorserEnemy horserEnemy, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        if (horserEnemy.CheckAttack())
        {
            if (horserEnemy.CanAttack())
                stateMchine.ContinueState(horserEnemy.attackState);
        }
        else
            stateMchine.ContinueState(horserEnemy.moveState);
    }
}
