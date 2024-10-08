using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserAllyBattleState : EntityState
{
    protected HorserAlly horser;
    public HorserAllyBattleState(Entity entity,HorserAlly horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.horser = horser;
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

        if (horser.CheckAttack())
        {
            if (horser.CanAttack())
                stateMchine.ContinueState(horser.attackState);
        }
        else
            stateMchine.ContinueState(horser.moveState);

        
    }
    
}