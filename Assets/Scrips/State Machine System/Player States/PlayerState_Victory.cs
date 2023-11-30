using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Victory" , fileName = "PlayeState_Victory")]
public class PlayerState_Victory : PlayerState
{
    [SerializeField] AudioClip[] voice;
   public override void Enter()
    {
        base.Enter();

        //关闭角色控制
        input.DisAbleGameplayInputs();

        //播放胜利音效
        player.VoicePlayer.PlayOneShot(voice[Random.Range(0, voice.Length)]);
    }
}
