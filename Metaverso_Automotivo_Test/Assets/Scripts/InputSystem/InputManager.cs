using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;

    public event Action<InputAction.CallbackContext> OnMove;
    public event Action OnOpenMenu;
    public event Action<bool> OnZoom; 

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();

        _playerInputSystem.Player.Movement.started += OnMovementInput;
        _playerInputSystem.Player.Movement.canceled += OnMovementInput;
        _playerInputSystem.Player.Movement.performed += OnMovementInput;

        _playerInputSystem.Player.OpenMenu.started += OnMenuInput;

        _playerInputSystem.Player.ZoomCamera.started += OnZoomInput;
        _playerInputSystem.Player.ZoomCamera.canceled += OnZoomInput;
    }

    private void OnZoomInput(InputAction.CallbackContext context)
    {
        OnZoom?.Invoke(context.ReadValueAsButton());
    }

    private void OnMenuInput(InputAction.CallbackContext context)
    {
        OnOpenMenu?.Invoke();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context);
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
        
        _playerInputSystem.Player.Movement.started -= OnMovementInput;
        _playerInputSystem.Player.Movement.canceled -= OnMovementInput;
        _playerInputSystem.Player.Movement.performed -= OnMovementInput;

        _playerInputSystem.Player.OpenMenu.started -= OnMenuInput;
        
        _playerInputSystem.Player.ZoomCamera.started -= OnZoomInput;
        _playerInputSystem.Player.ZoomCamera.canceled -= OnZoomInput;
    }
}
