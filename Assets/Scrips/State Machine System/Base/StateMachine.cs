using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

    protected Dictionary<System.Type, IState> stateTable;

    void Update()
    {
        currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    //状态机启动
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    //状态机内部状态转换
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
    public void SwitchState(System.Type newStateType)
    {
        SwitchOn(stateTable[newStateType]);
    }
}
