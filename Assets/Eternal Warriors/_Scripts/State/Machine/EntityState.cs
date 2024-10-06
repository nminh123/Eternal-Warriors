using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState
{
    protected EntityStateMachine stateMchine;
    protected Entity entity;

    protected string boolName;

    public EntityState(Entity entity, EntityStateMachine stateMchine, string boolName)
    {
        this.entity = entity;
        this.stateMchine = stateMchine;
        this.boolName = boolName;
    }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Logic()
    {

    }
}
