using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyyoteTime" , fileName ="PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] private float runSpeed = 5f;

    //土狼时间
    [SerializeField]private float coyoteTime = 0.1f;
    public override void Enter()
    {
        //animator.Play("Run");
        base.Enter();
        player.SetUseGravity(false);
    }

    public override void Exit()
    {
        player.SetUseGravity(true);
    }
    public override void LogicUpdate()
    {
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (StateDuration > coyoteTime || input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(runSpeed);
    }
}
