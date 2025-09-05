public abstract class PlayerBaseState
{
    public abstract void OnEnter(PlayerStateMachine player);
    public abstract void UpdateLogic(PlayerStateMachine player);
    public abstract void UpdatePhysics(PlayerStateMachine player);
    public abstract void OnExit(PlayerStateMachine player);
}
