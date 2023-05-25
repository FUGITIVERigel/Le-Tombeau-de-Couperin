using UnityEngine;

[CreateAssetMenu(fileName = "Run", menuName = "Data/PlayerState/Run")]
public class Run : PlayerState
{   
    public float acceleration; 
    public override void Enter()
    {
        base.Enter();
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
        currentSpeed = Mathf.MoveTowards(currentSpeed, player.moveSpeed, acceleration*Time.deltaTime);
        player.Run(currentSpeed);
    }
    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if(input.MoveX==0){
            stateMachine.SwitchOn(stateMachine.stateTable[typeof(Idle)]);
        }
        if(input.isJump){
            stateMachine.SwitchOn(stateMachine.stateTable[typeof(Jump)]);
        }
    }
}
