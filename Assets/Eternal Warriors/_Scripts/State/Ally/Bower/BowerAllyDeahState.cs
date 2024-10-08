using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowerAllyDeahState : EntityState
{
    protected BowerAlly bowerAlly;
    public BowerAllyDeahState(Entity entity, BowerAlly bowerAlly, EntityStateMachine stateMchine, string boolName) : base(entity, stateMchine, boolName)
    {
        this.bowerAlly = bowerAlly;
    }

    public override void Enter()
    {
        base.Enter();
        startTime = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Logic()
    {
        base.Logic();
        if(startTime <= 0)
        {
            bowerAlly.ReturnToPool();
            bowerAlly.gameObject.SetActive(false);
        }
    }
}
