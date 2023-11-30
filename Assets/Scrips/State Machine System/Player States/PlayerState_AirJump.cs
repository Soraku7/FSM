using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump" , fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [SerializeField] private float JumpForce = 2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private ParticleSystem jumpVFX;
    [SerializeField] private AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();
        player.VoicePlayer.PlayOneShot(jumpSFX);
        player.CanAirJump = false;
        player.SetVelocityY(JumpForce);
        Instantiate( jumpVFX, player.transform.position, Quaternion.identity);
        Debug.Log("二段跳");
    }
    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed);
    }
}
