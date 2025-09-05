using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState
{
    private NavMeshAgent agent;

    public override void OnEnter(EnemyController enemy)
    {
        agent = enemy.GetComponent<NavMeshAgent>();
        agent.isStopped = false;
    }

    public override void UpdateLogic(EnemyController enemy)
    {
        // Se o player desaparecer, volta para idle
        if (enemy.Target == null)
        {
            enemy.GetComponent<EnemyStateMachine>().SwitchState(new EnemyIdleState());
        }
    }

    public override void UpdatePhysics(EnemyController enemy)
    {
        if (enemy.Target != null)
        {
            agent.SetDestination(enemy.Target.position);
        }
    }

    public override void OnExit(EnemyController enemy)
    {
        agent.isStopped = true;
    }
}
