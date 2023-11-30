using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    [SerializeField, Range(0f, 1f)] float transitionDuration = 0.1f; 
    int stateHash;
    protected Animator animator;

    private float stateStartTime;

    //状态机实例
    protected PlayerStateMachine stateMachine;

    //玩家输入
    protected PlayerInput input;

    //玩家控制器
    protected PlayerControler player;

    //玩家速度
    protected float currentSpeed;

    //判断动画是否播放完
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    //状态持续时间
    protected float StateDuration => Time.time - stateStartTime;
    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }
    //获取组件
    public void Initialize(Animator animator , PlayerStateMachine stateMachine , PlayerInput input , PlayerControler player)
    {
        this.animator = animator;
        this.input = input;
        this.stateMachine = stateMachine;
        this.player = player;
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }
}
