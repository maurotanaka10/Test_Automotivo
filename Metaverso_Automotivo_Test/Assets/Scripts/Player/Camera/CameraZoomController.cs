using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private void Awake()
    {
        PlayerManager.HandleZoomInput += HandleZoom;
    }

    private void HandleZoom(bool isZoom)
    {
        if (isZoom)
        {
            _camera.fieldOfView = 25f;
        }
        else
        {
            _camera.fieldOfView = 50f;
        }
    }

    private void OnDisable()
    {
        PlayerManager.HandleZoomInput -= HandleZoom;
    }
}
