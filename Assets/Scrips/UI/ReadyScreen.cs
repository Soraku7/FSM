using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelStartEventChannel;
    [SerializeField] AudioClip startVoice;
    void LevelStart()
    {
        levelStartEventChannel.Broadcast();

        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    private void PlayerStartVoice()
    {
        SoundEffectPlayer.AudioSource.PlayOneShot(startVoice);
    }
}
