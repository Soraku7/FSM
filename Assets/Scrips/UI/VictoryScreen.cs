using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEvent;
    [SerializeField] Button nextLevelButton;

    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    [SerializeField] Text Timetext;
    private void OnEnable()
    {
        levelClearedEvent.AddListener(ShowUI);
        clearTimeTextEventChannel.AddListener(SetTimeText);
        nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScence);

    }
    private void OnDisable()
    {
        levelClearedEvent.RemoveListener(ShowUI);
        clearTimeTextEventChannel.RemoveListener(SetTimeText);
        nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScence);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        Cursor.lockState = CursorLockMode.None;

    }

    private void SetTimeText(string obj)
    {
        Timetext.text = obj;
    }
}
