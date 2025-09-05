using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void OnEnter(EnemyController enemy) { }

    public override void UpdateLogic(EnemyController enemy)
    {
        // Se tiver player, passa para chase
        if (enemy.Target != null)
        {
            enemy.GetComponent<EnemyStateMachine>().SwitchState(new EnemyChaseState());
        }
    }

    public override void UpdatePhysics(EnemyController enemy) { }

    public override void OnExit(EnemyController enemy) { }
}
