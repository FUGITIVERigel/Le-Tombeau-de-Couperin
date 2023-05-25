using UnityEngine;

[CreateAssetMenu(fileName = "Idle", menuName = "Data/PlayerState/Idle")]
public class Idle : PlayerState
{
    public float deceleration;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = player.moveSpeed;
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration*Time.deltaTime);
        player.Run(currentSpeed);
    }
    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if(input.MoveX!=0){
            stateMachine.SwitchState(stateMachine.stateTable[typeof(Run)]);
        }
        if(input.isJump){
            stateMachine.SwitchState(stateMachine.stateTable[typeof(Jump)]);
        }
    }
}
