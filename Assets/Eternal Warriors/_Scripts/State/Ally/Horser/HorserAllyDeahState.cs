using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserAllyDeahState : EntityState
{
    protected HorserAlly horser;
    public HorserAllyDeahState(Entity entity, HorserAlly horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.horser = horser;
    }

    public override void Enter()
    {
        base.Enter();
        startTime = 1.6f;
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