using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private UIManager _uiManager;

    public static event Action<InputAction.CallbackContext> OnMoveInputContextReceived;
    public static event Action OnOpenMenuInputContextReceived;
    public static event Action<bool> OnZoomInputContextReceived;

    private void Awake()
    {
        _inputManager.OnMove += OnMoveInputHandler;
        _inputManager.OnOpenMenu += OnOpenMenuInputHandler;
        _inputManager.OnZoom += OnZoomInputHandler;
    }

    private void OnZoomInputHandler(bool isZoomCamera)
    {
        OnZoomInputContextReceived?.Invoke(isZoomCamera);
    }

    private void OnOpenMenuInputHandler()
    {
        OnOpenMenuInputContextReceived?.Invoke();
    }

    private void OnMoveInputHandler(InputAction.CallbackContext context)
    {
        OnMoveInputContextReceived?.Invoke(context);
    }

    private void OnDisable()
    {
        _inputManager.OnMove -= OnMoveInputHandler;
        _inputManager.OnOpenMenu -= OnOpenMenuInputHandler;
        _inputManager.OnZoom -= OnZoomInputHandler;
    }
}
