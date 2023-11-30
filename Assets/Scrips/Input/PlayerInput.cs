using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]private float JumpInputBufferTime = 0.5f;
    WaitForSeconds waitJumpInputBufferTime;

    PlayerInputAction playerInputAction;

    private Vector2 axes => playerInputAction.GamePlay.Axes.ReadValue<Vector2>();
    public bool Jump => playerInputAction.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();

    public bool Move => AxisX != 0f;
    public float AxisX => axes.x;

    public bool HasJumpInputBuffer { get; set; }
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();

        waitJumpInputBufferTime = new WaitForSeconds(JumpInputBufferTime);
    }
    private void OnEnable()
    {
        playerInputAction.GamePlay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }
    public void EnableGamelayInputs()
    {
        playerInputAction.GamePlay.Enable();
        //将光标设定为锁定模式
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBuferCoroutine));
        StartCoroutine(nameof(JumpInputBuferCoroutine));
    }
    IEnumerator JumpInputBuferCoroutine()
    {
        HasJumpInputBuffer = true;

        yield return waitJumpInputBufferTime;

        HasJumpInputBuffer = false;
    }
    public void DisAbleGameplayInputs()
    {
        playerInputAction.GamePlay.Disable();
    }
}
