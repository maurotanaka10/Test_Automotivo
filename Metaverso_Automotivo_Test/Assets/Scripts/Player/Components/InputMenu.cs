using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private CameraRotation _cameraRotation;

    private bool _menuIsOpened = false;
    private float _sensitivityReference, _smoothingReference;
    
    private void Awake()
    {
        PlayerManager.HandleOpenMenu += MenuHandler;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _sensitivityReference = _cameraRotation._sensitivity;
        _smoothingReference = _cameraRotation._smoothing;
    }

    private void MenuHandler()
    {
        if (_menuIsOpened == false)
        {
            _menuIsOpened = true;
            _menuCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            _cameraRotation._sensitivity = 0f;
            _cameraRotation._smoothing = 0f;
        }
        else
        {
            _menuIsOpened = false;
            _menuCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            _cameraRotation._sensitivity = _sensitivityReference;
            _cameraRotation._smoothing = _smoothingReference;
        }
    }

    private void OnDisable()
    {
        PlayerManager.HandleOpenMenu -= MenuHandler;
    }
}
