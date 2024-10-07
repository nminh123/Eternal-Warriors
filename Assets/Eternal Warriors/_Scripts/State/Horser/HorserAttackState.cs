using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserAttackState : EntityState
{
    protected Horser horser;
    public HorserAttackState(Entity entity, Horser horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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

        if(isCalled)
            stateMchine.ContinueState(horser.battleState);
    }
}
