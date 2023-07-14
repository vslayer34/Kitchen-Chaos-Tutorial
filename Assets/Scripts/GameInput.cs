using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    PlayerInputAction playerInputAction;
    public event EventHandler OnInteractionAction;
    public event EventHandler OnInteractionAlternativeAction;


    void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.InteractAlternative.performed += InteractAlternative_performed;
    }

    private void InteractAlternative_performed(InputAction.CallbackContext obj)
    {
        OnInteractionAlternativeAction?.Invoke(this, EventArgs.Empty);
    }

    void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractionAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetInputVectorNormalized()
    {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();

        return inputVector.normalized;
    }
}
