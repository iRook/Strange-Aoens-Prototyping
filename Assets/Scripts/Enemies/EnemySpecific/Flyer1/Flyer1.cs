using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer1 : Entity
{
    public F1_MoveState moveState { get; private set; }
    public F1_IdleState idleState { get; private set; }
    public F1_FollowState followState { get; private set; }
    public F1_PlayerDetectedState playerDetectedState { get; private set; }
    public F1_MeleeAttackState meleeAttackState { get; private set; }
    public F1_LookForPlayerState lookForPlayerState { get; private set; }
    public F1_StunState stunState { get; private set; }
    public F1_DeadState deadState { get; private set; }

    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_FollowState followStateData;
    [SerializeField] private D_PlayerDetectedState playerDetectedStateData;
    [SerializeField] private D_MeleeAttack meleeAttackStateData;
    [SerializeField] private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;

    [SerializeField] private Transform meleeAttackPosition;
    internal State lookingForPlayerState;

    public override void Start()
    {
        base.Start();

        moveState = new F1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new F1_IdleState(this, stateMachine, "idle", idleStateData, this);
        followState = new F1_FollowState(this, stateMachine, "follow", followStateData, this);
        playerDetectedState = new F1_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new F1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new F1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new F1_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new F1_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (CheckPlayerInMinAgroRange())
        {
            stateMachine.ChangeState(meleeAttackState);
        }
        else if (!CheckPlayerInMinAgroRange())
        {
            lookForPlayerState.SetTurnImmediately(true);
            stateMachine.ChangeState(lookForPlayerState);
        }
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
}
