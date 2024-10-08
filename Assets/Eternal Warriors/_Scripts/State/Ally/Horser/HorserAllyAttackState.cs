using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserAllyAttackState : EntityState
{
    protected HorserAlly horser;
    public HorserAllyAttackState(Entity entity, HorserAlly horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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
