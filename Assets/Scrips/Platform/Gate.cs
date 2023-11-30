using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private VoidEventChannel gateTriggerEventChannel;
    private void OnEnable()
    {
        gateTriggerEventChannel.AddListener(Open);
    }

    private void OnDisable()
    {
        gateTriggerEventChannel.RemoveListener(Open);
    }
    private void Open()
    {
        Destroy(gameObject);
    }
}
