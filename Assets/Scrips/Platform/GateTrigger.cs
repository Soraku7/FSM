using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateVoidEventChannel;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] ParticleSystem pickUpVFX;
    private void OnTriggerEnter(Collider other)
    {
        gateVoidEventChannel.Broadcast();
        //播放音效和特效
        SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSound);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
