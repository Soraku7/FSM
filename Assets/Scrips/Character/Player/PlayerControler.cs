using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearEventChannel;
    PlayerGroundDetect groundDetector;

    PlayerInput input;

    Rigidbody rigidBody;

    public bool Victory;
    public AudioSource VoicePlayer { get; private set; }
    public bool CanAirJump { get; set; }
    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);

    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => rigidBody.velocity.y < 0f && !IsGrounded;
    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetect>();
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        VoicePlayer = GetComponentInChildren<AudioSource>();
    }
    private void OnEnable()
    {
        levelClearEventChannel.AddListener(OnLevelCleared);
    }
    private void OnDisable()
    {
        levelClearEventChannel.RemoveListener(OnLevelCleared);
    }
    void OnLevelCleared()
    {
        Victory = true;
    }
    public void OnDefeted()
    {
        input.DisAbleGameplayInputs();

        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
        rigidBody.detectCollisions = false;

        //通知状态机切换失败状态
        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }
    private void Start()
    {
        input.EnableGamelayInputs();
    }

    //更改玩家朝向
    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);
        }
        SetVelocityX(speed * input.AxisX);
    }

    //改变玩家刚体
    public void SetVelocity(Vector2 velocity)
    {
        rigidBody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidBody.velocity = new Vector2(velocityX, rigidBody.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, velocityY);
    }

    public void SetUseGravity(bool value)
    {
        rigidBody.useGravity = value;
    }
}
