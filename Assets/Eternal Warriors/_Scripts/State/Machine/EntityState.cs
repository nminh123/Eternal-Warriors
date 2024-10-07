using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState
{
    protected EntityStateMachine stateMchine;
    protected Entity entity;

    protected string boolName;
    protected float startTime;
    protected bool isCalled;

    public EntityState(Entity entity, EntityStateMachine stateMchine, string boolName)
    {
        this.entity = entity;
        this.stateMchine = stateMchine;
        this.boolName = boolName;
    }

    public virtual void Enter()
    {
        entity.animator.SetBool(boolName, true);
        isCalled = false;
    }
    public virtual void Exit()
    {
        entity.animator.SetBool(boolName, false);
        isCalled = true;
    }
    public virtual void Logic()
    {
        startTime -= Time.deltaTime;
    }
    public void CheckAnimationAttack()
    {
        isCalled = true;
    }
}
