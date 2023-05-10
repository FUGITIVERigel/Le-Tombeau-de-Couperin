public interface IState
{
  void Enter();
  void Exit();
  void PhysicalUpdate();
  void LogicalUpdate();
}
