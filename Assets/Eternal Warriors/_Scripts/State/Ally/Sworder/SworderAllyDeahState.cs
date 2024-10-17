using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworderAllyDeahState : EntityState
{
    protected SworderAlly sworderAlly;
    public SworderAllyDeahState(Entity entity, SworderAlly sworderAlly, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.sworderAlly = sworderAlly;
    }

    public override void Enter()
    {
        base.Enter();
        startTime = 1.1f;
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void Logic()
    {
        base.Logic();

        if (islife)
            sworderAlly.ReturnPool(sworderAlly.gameObject);
    }
}

