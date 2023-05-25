using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    [SerializeField,Range(0f,1f)] float transitionDuration=0.1f;
    int stateHash;
    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerController player;
    protected AudioManage audioManage;
    protected PlayerInput input;
    protected AudioSource audioSource;
    protected float stateStartTime;
    protected float currentSpeed;
    protected float stateDuration=>Time.time-stateStartTime;//stateDuration is the time since the state started
    protected bool isAniFinished;
    void OnEnable()
    {
        stateHash=Animator.StringToHash(stateName);
    }
    public void Initialized(Animator animator,PlayerStateMachine stateMachine,PlayerInput input,PlayerController player,AudioSource audioSource,AudioManage audioManage)
    {
        this.animator=animator;
        this.stateMachine=stateMachine;
        this.input=input;
        this.player=player;
        this.audioSource=audioSource;
        this.audioManage=audioManage;
    }
    public virtual void Enter()
    {
        animator.CrossFade(stateHash,transitionDuration);
        stateStartTime=Time.time;
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicalUpdate()
    {
    }

    public virtual void PhysicalUpdate()
    {
    }
}
