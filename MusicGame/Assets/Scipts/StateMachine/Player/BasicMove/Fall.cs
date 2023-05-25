using UnityEngine;
[CreateAssetMenu(fileName = "Fall", menuName = "Data/PlayerState/Fall")]
public class Fall : PlayerState
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
        if(player.isGround){
            stateMachine.SwitchState(stateMachine.stateTable[typeof(Idle)]);
        }
    }
}