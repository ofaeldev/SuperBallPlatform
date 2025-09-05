using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public InputReader Input;

    private PlayerStateMachine stateMachine;

    public PlayerData Data;

    void Awake()
    {
        stateMachine = GetComponent<PlayerStateMachine>();
    }

    void Update()
    {
        // Se o player começa a mover, muda o estado
        if (Input.Move != Vector2.zero && !(stateMachine.CurrentState is PlayerMovingState))
        {
            stateMachine.SwitchState(new PlayerMovingState(Data));
        }
    }
}
