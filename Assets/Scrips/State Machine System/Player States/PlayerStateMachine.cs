using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [SerializeField]PlayerState[] states;

    Animator animator;

    PlayerInput input;

    PlayerControler player;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerControler>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);
        //对具体状态初始化 
        foreach (PlayerState state in states)
        {
            state.Initialize(animator, this , input , player);
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
