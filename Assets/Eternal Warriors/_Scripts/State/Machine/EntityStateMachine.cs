using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine
{
    public EntityState currentState;

    public void StartState(EntityState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void ContinueState(EntityState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
