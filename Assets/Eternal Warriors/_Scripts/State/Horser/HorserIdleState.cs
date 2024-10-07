using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserIdleState : EntityState
{
    private Horser horser;
    public HorserIdleState(Entity entity, Horser horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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
    }
}