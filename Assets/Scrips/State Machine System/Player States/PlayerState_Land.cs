using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Land" , fileName = "PlayerState_Land") ]
public class PlayerState_Land : PlayerState
{
    //玩家的硬直时间
    [SerializeField] float stiffTime = 0.2f;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(Vector3.zero);
    }
    public override void LogicUpdate()
    { 
        if (input.Jump || input.HasJumpInputBuffer)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        if(StateDuration < stiffTime)
        {
            return;
        }
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (player.Victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }
    }
}
