using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static event Action<InputAction.CallbackContext> HandleMoveInput;
    public static event Action<bool> HandleZoomInput;
    public static event Action HandleOpenMenu;

    private void Awake()
    {
        GameManager.OnMoveInputContextReceived += HandleMove;
        GameManager.OnZoomInputContextReceived += HandleZoom;
        GameManager.OnOpenMenuInputContextReceived += HandleMenuInput;
    }
    
    private void HandleMenuInput()
    { 
        HandleOpenMenu?.Invoke();
    }

    private void HandleZoom(bool isZoomCamera)
    {
        HandleZoomInput?.Invoke(isZoomCamera);
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        HandleMoveInput?.Invoke(context);
    }

    private void OnDisable()
    {
        GameManager.OnMoveInputContextReceived -= HandleMove;
        GameManager.OnZoomInputContextReceived -= HandleZoom;
        GameManager.OnOpenMenuInputContextReceived -= HandleMenuInput;
    }
}
