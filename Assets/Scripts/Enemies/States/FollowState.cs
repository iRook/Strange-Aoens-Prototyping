using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{

    protected D_FollowState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMaxCircleAgroRange;

    public FollowState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_FollowState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        // moved out of enter method and physicsupdate method
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMaxCircleAgroRange = entity.CheckPlayerInMaxCircleAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        //entity.SetFlyingVelocity(stateData.followSpeed);
        entity.transform.position = Vector2.MoveTowards(entity.transform.position, stateData.whereIsPlayer.transform.position, stateData.followSpeed * Time.deltaTime);
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
