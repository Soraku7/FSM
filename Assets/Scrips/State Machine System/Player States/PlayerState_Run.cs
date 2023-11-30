using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Run" , fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] private float runSpeed = 5f;
    //加速度
    [SerializeField] private float acceleration = 5f;
    public override void Enter()
    {
        //animator.Play("Run");
        base.Enter();
        currentSpeed = player.MoveSpeed;
    }
    public override void LogicUpdate()
    {
        if(!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(currentSpeed);
    }
}
