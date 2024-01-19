using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1_PlayerDetectedState : PlayerDetectedState
{
    private Flyer1 enemy;

    public F1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData, Flyer1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        //if (performCloseRangeAction)
        //{
        //    stateMachine.ChangeState(enemy.meleeAttackState);
        //}
        //else if (performLongRangeAction)
        //{
        //    //enemy.idleState.SetFlipAfterIdle(false); removed when created charge state in part 15
        //    stateMachine.ChangeState(enemy.chargeState);
        //}
        if (isPlayerInMinCircleAgroRange)
        {
            stateMachine.ChangeState(enemy.followState);
        }
        else if (!isPlayerInMaxCircleAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        //else if (!isPlayerInMaxAgroRange)
        //{
        //    stateMachine.ChangeState(enemy.lookForPlayerState);
        //}
        //else if (!isDetectingLedge)
        //{
        //    entity.Flip();
        //    stateMachine.ChangeState(enemy.moveState);
        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
