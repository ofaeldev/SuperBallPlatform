using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyBaseState currentState;
    private EnemyController enemy;

    public EnemyController Enemy => enemy;

    public void Initialize(EnemyController enemyController)
    {
        enemy = enemyController;
        SwitchState(new EnemyIdleState());
    }

    void Update()
    {
        currentState?.UpdateLogic(enemy);
        currentState?.UpdatePhysics(enemy);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState?.OnExit(enemy);
        currentState = newState;
        currentState?.OnEnter(enemy);
    }
}
