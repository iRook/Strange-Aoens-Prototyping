using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1_FollowState : FollowState
{
    private Flyer1 enemy;

    public F1_FollowState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_FollowState stateData, Flyer1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (!isPlayerInMaxCircleAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}