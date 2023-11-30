using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump" , fileName = "PlayerState_Jump")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] private float JumpForce = 2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private ParticleSystem jumpVFX;
    [SerializeField] private AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        player.VoicePlayer.PlayOneShot(jumpSFX);
        player.SetVelocityY(JumpForce);
        Instantiate(original: jumpVFX, player.transform.position, Quaternion.identity);

        //关闭跳跃动作缓冲
        input.HasJumpInputBuffer = false;
    }
    public override void LogicUpdate()
    {
        if (input.StopJump ||player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed); 
    }
}
