using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearTime : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] VoidEventChannel levelStartEventChannel;
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    bool stop = true;

    float clearTime;

    private void OnEnable()
    {
        levelStartEventChannel.AddListener(LevelStart);
        levelClearedEventChannel.AddListener(LevelClear);
    }

    private void OnDisable()
    {
        levelStartEventChannel.RemoveListener(LevelStart);
        levelClearedEventChannel.RemoveListener(LevelClear);
    }
    private void FixedUpdate()
    {
        if (stop) return;
        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    private void LevelStart()
    {
        stop = false;
    }
    private void LevelClear()
    {
        stop = true;
        clearTimeTextEventChannel.Broadcast(timeText.text);
    }
}
