﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1_LookForPlayerState : LookForPlayerState
{
    private Flyer1 enemy;

    public F1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData, Flyer1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
