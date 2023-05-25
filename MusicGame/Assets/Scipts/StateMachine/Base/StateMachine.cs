using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

    public Dictionary<System.Type, IState> stateTable;

    private void Update()
    {
        currentState.LogicalUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicalUpdate();
    }

    public void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }

}
