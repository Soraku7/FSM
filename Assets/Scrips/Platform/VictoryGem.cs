using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGem : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearEventChannel;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] ParticleSystem pickUpVFX;
    private void OnTriggerEnter(Collider other)
    {
        //播放音效和特效
        levelClearEventChannel.Broadcast();
        SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSound);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
