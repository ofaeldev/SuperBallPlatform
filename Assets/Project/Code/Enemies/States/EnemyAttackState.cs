using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public float attackRange = 1.5f;

    public override void OnEnter(EnemyController enemy) { }

    public override void UpdateLogic(EnemyController enemy)
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.Target.position);

        // Volta para chase se o player estiver longe
        if (distance > attackRange)
        {
            enemy.GetComponent<EnemyStateMachine>().SwitchState(new EnemyChaseState());
        }
        else
        {
            // Aqui você pode aplicar dano ou efeito
            Debug.Log("Atacando player!");
        }
    }

    public override void UpdatePhysics(EnemyController enemy) { }

    public override void OnExit(EnemyController enemy) { }
}
