using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementComponent : MonoBehaviour
{
    private CharacterController _characterController;

    private Vector2 _characterMovementInput;
    private float _verticalVelocity;
    private Vector3 _playerMovementForward;
    private Vector3 _playerMovementStrafe;
    private Vector3 _playerGravity;
    private float _playerVelocity;

    [Tooltip("Player walk velocity")] [SerializeField]
    private float _walkVelocity;

    [Tooltip("Player rotation velocity")] [SerializeField]
    private float _rotationVelocity;

    [SerializeField] private float _gravity;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        PlayerManager.HandleMoveInput += SetMovementInfo;
    }


    private void FixedUpdate()
    {
        SetMovement(_characterMovementInput);
    }
    private void SetMovementInfo(InputAction.CallbackContext context)
    {
        _characterMovementInput = context.ReadValue<Vector2>();
    }

    private void SetMovement(Vector2 _characterMovementInput)
    {
        _playerVelocity = _walkVelocity;
        
        _playerMovementForward = _characterMovementInput.y * _playerVelocity * transform.forward;
        _playerMovementStrafe = _characterMovementInput.x * _playerVelocity * transform.right;

        Vector3 finalMovement = _playerMovementForward + _playerMovementStrafe;
        _characterController.Move(finalMovement * Time.deltaTime);

        _verticalVelocity += _gravity * Time.deltaTime;

        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
    }
    
    private void OnDisable()
    {
        PlayerManager.HandleMoveInput -= SetMovementInfo;
    }
}