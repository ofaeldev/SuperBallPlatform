public abstract class EnemyBaseState
{
    public abstract void OnEnter(EnemyController enemy);
    public abstract void UpdateLogic(EnemyController enemy);
    public abstract void UpdatePhysics(EnemyController enemy);
    public abstract void OnExit(EnemyController enemy);
}
