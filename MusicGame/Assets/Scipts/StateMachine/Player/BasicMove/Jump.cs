using UnityEngine;

[CreateAssetMenu(fileName = "Jump", menuName = "Data/PlayerState/Jump")]
public class Jump : PlayerState
{
    [SerializeField] float inAirSpeedX;
    [SerializeField] float decelerationX;
    [SerializeField] AnimationCurve speedCurve;
    public override void Enter()
    {
        base.Enter();
        currentSpeed = player.moveSpeed;
    }
    public override void PhysicalUpdate()
    {
        base.PhysicalUpdate();
        currentSpeed = Mathf.MoveTowards(currentSpeed, inAirSpeedX, decelerationX * Time.deltaTime);//X方向的减速运动
        player.MoveY(speedCurve.Evaluate(stateDuration));//Y方向的速度曲线
        player.MoveX(currentSpeed * input.MoveX);
        
    }
    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if(player.rb.velocity.y<0||input.isStopJump){
            stateMachine.SwitchState(stateMachine.stateTable[typeof(Fall)]);
        }
    }
}
