using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;
    Animator animator;
    PlayerInput input;
    PlayerController player;
    AudioManage audioManage;
    AudioSource audioSource;
    private void Awake(){
        animator=GetComponentInChildren<Animator>();
        input=GetComponent<PlayerInput>();
        player=GetComponent<PlayerController>();
        stateTable=new Dictionary<System.Type, IState>(states.Length);
        audioSource=GetComponentInChildren<AudioSource>();
        audioManage=GetComponentInChildren<AudioManage>();
        foreach (var state in states)
        {
            state.Initialized(animator,this,input,player,audioSource,audioManage);
            stateTable.Add(state.GetType(),state);
        }
    }
    private void Start(){
        SwitchOn(stateTable[typeof(Idle)]);
    }
}
