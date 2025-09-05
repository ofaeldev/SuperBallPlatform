using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerBaseState CurrentState { get; private set; }

    void Start()
    {
        SwitchState(new PlayerIdleState());
    }

    public void Update()
    {
        CurrentState?.UpdateLogic(this);
    }

    void FixedUpdate()
    {
        CurrentState?.UpdatePhysics(this);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        CurrentState?.OnExit(this);
        CurrentState = newState;
        CurrentState?.OnEnter(this);
    }
}
