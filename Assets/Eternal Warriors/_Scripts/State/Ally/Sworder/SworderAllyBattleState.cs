using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderAllyBattleState : EntityState
{
    protected SworderAlly sworderAlly;
    public SworderAllyBattleState(Entity entity, SworderAlly sworderAlly, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworderAlly = sworderAlly;
    }

    public override void Enter()
    {
        base.Enter();
        
        sworderAlly.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();

        if (sworderAlly.CheckAttack())
        {
            if(sworderAlly.CheckAttack().distance < .4f)
            {
                if (sworderAlly.CanAttack())
                    stateMchine.ContinueState(sworderAlly.attackState);
            }        
        }
        else
        {
            stateMchine.ContinueState(sworderAlly.moveState);
        }
           
    }
}
