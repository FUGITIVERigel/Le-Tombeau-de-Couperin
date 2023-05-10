using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;
    Animator animator;
    PlayerInput input;
    private void Awake(){
        animator=GetComponentInChildren<Animator>();
        stateTable=new Dictionary<System.Type, IState>(states.Length);
        foreach (var state in states)
        {
            state.Initialized(animator,this,input);
            stateTable.Add(state.GetType(),state);
        }
    }
}
