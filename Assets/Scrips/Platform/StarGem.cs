using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3.0f;
    [SerializeField] AudioClip pickUpSFX;
    [SerializeField] ParticleSystem pickUpVFX;
    //关闭渲染
    MeshRenderer meshRenderer;


    new Collider collider;

    WaitForSeconds waitResetTime;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        collider = GetComponent<Collider>();
        waitResetTime = new WaitForSeconds(resetTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerControler>(out PlayerControler player))
        {
            player.CanAirJump = true;
            collider.enabled = false;
            
            meshRenderer.enabled = false;

            //播放音效
            SoundEffectPlayer.AudioSource.PlayOneShot(pickUpSFX); 

            //生成拾取特效
            Instantiate(pickUpVFX, transform.position, transform.rotation);
            //延时调用函数
            //Invoke(nameof(Reset), resetTime);
            StartCoroutine(ResetCoroutine());
        }
    }

    private void Reset()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }

    IEnumerator ResetCoroutine()
    {
        yield return waitResetTime;

        Reset();
    }
}
