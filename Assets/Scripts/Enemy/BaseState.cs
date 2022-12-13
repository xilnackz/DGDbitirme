using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class BaseState

    {
    protected StateMachine stateMachine;

    public string name;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void UpdateLogic()
    {
    }

    public virtual void UpdatePhysics()
    {
    }

    public virtual void Exit()
    {
    }
    }
}
