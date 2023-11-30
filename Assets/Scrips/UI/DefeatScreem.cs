using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreem : MonoBehaviour
{
    [SerializeField] VoidEventChannel playerDefeatedClearedEvent;
    [SerializeField] AudioClip[] voice;

    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;
    private void OnEnable()
    {
        playerDefeatedClearedEvent.AddListener(ShowUI);
        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }
    private void OnDisable()
    {
        playerDefeatedClearedEvent.RemoveListener(ShowUI);
        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        AudioClip retryVoice  = voice[Random.Range(0 , voice.Length)];
        SoundEffectPlayer.AudioSource.PlayOneShot(retryVoice);

        Cursor.lockState = CursorLockMode.None;
    }
}
