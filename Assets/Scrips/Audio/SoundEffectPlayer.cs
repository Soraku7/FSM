using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public static AudioSource AudioSource{ get; private set; }

    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

        //关闭在唤醒是开始声音
        AudioSource.playOnAwake = false;
    }

}
