using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorserMoveState : EntityState
{
    protected Horser horser;
    public HorserMoveState(Entity entity, Horser horser, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
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
      
        horser.SetVelocity(horser.speed);

        if(horser.CheckAttack())
            stateMchine.ContinueState(horser.battleState);
    }
}