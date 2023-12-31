using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Defeated", fileName = "PlayerState_Defeated")]
public class PlayerState_Defeated : PlayerState
{
    [SerializeField] ParticleSystem vfx;
    [SerializeField] AudioClip[] voice;

    public override void Enter()
    {
        base.Enter();
        //生成特效
        Instantiate(vfx, player.transform.position, Quaternion.identity);
        //播放音效
        AudioClip deathVoice = voice[Random.Range(0, voice.Length)];

        player.VoicePlayer.PlayOneShot(deathVoice);
    }

    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }
}
