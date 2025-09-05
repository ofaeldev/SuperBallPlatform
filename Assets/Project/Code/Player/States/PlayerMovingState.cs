using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private Rigidbody rb;
    private InputReader input;
    private float moveForce;

    public PlayerMovingState(PlayerData data)
    {
        moveForce = data.moveForce;
    }
    public override void OnEnter(PlayerStateMachine player)
    {
        rb = player.GetComponent<Rigidbody>();
        input = player.GetComponent<PlayerController>().Input;
    }

    public override void UpdateLogic(PlayerStateMachine player)
    {
        // Se não houver input, volta para Idle
        if (input.Move == Vector2.zero)
            player.SwitchState(new PlayerIdleState());
    }

    public override void UpdatePhysics(PlayerStateMachine player)
    {
        // Converte o input (Vector2) em direção no plano XZ
        Vector3 force = new Vector3(input.Move.x, 0, input.Move.y) * moveForce;
        // Aplica força para rolagem natural da bola
        rb.AddForce(force, ForceMode.Force);

        // Mantém o movimento no plano (impede "quicar" para cima)
        Vector3 vel = rb.linearVelocity;
        vel.y = 0;
        rb.linearVelocity = vel;
    }

    public override void OnExit(PlayerStateMachine player) { }
}
