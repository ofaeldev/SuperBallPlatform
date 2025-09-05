using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions
{
    public Vector2 Move { get; private set; }

    private PlayerInputActions _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new PlayerInputActions();
            _gameInput.Player.SetCallbacks(this);
        }
        _gameInput.Player.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }
}
