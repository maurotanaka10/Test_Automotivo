using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    [SerializeField] private LightsCar _lightsCar;
    [SerializeField] private OpenCloseDoors _openCloseDoors;
    [SerializeField] private ExitGame _exitGame;

    public bool _theCarIsRunning = false;
    public bool _theDoorsAreOpen = false;
    public bool _frontRightHeadlightIsOn = false;
    public bool _frontLeftHeadlightIsOn = false;
    public bool _backRightHeadlightIsOn = false;
    public bool _backLeftHeadlightIsOn = false;

    [SerializeField] private Button _turnOnTheCarButton;
    [SerializeField] private TextMeshProUGUI _turnOnTheCarText;
    [SerializeField] private Button _openTheDoorsButton;
    [SerializeField] private Material[] _carMateiral;
    [SerializeField] private Renderer[] _carRenderer;
    [SerializeField] private Button _changeColorBackButton;
    [SerializeField] private Button _changeColorNextButton;
    [SerializeField] private Button _turnOnTheLightFrontRightButton;
    [SerializeField] private TextMeshProUGUI _turnOnTheLightFrontRightText;
    [SerializeField] private Button _turnOnTheLightFrontLeftButton;
    [SerializeField] private TextMeshProUGUI _turnOnTheLightFrontLeftText;
    [SerializeField] private Button _turnOnTheLightBackRightButton;
    [SerializeField] private TextMeshProUGUI _turnOnTheLightBackRightText;
    [SerializeField] private Button _turnOnTheLightBackLeftButton;
    [SerializeField] private TextMeshProUGUI _turnOnTheLightBackLeftText;
    [SerializeField] private Button _exitGameButton;

    private int _currentMaterialIndex = 0;
    
    private void Awake()
    {
        _turnOnTheCarButton.onClick.AddListener(() => OnTurnOnTheCar());
        _openTheDoorsButton.onClick.AddListener(() => _openCloseDoors.ToggleDoorState());
        _turnOnTheLightFrontRightButton.onClick.AddListener(() => OnTurnOnFrontRightHeadlight());
        _turnOnTheLightFrontLeftButton.onClick.AddListener(() => OnTurnOnFrontLeftHeadlight());
        _turnOnTheLightBackRightButton.onClick.AddListener(() => OnTurnOnBackRightHeadlight());
        _turnOnTheLightBackLeftButton.onClick.AddListener(() => OnTurnOnBackLeftHeadlight());
        _changeColorBackButton.onClick.AddListener(() => OnChangeBackMaterialCar());
        _changeColorNextButton.onClick.AddListener(() => OnChangeNextMaterialCar());
        _exitGameButton.onClick.AddListener(()=> _exitGame.QuitGame());
    }

    private void Start()
    {
        HandleAllHeadlightOff();
        UpdateCarMaterial();
    }

    private void OnChangeBackMaterialCar()
    {
        _currentMaterialIndex--;
        if (_currentMaterialIndex < 0)
        {
            _currentMaterialIndex = _carMateiral.Length - 1;
        }
        UpdateCarMaterial();
    }

    private void OnChangeNextMaterialCar()
    {
        _currentMaterialIndex++;
        if (_currentMaterialIndex >= _carMateiral.Length)
        {
            _currentMaterialIndex = 0;
        }
        UpdateCarMaterial();
    }

    private void UpdateCarMaterial()
    {
        if (_carRenderer != null)
        {
            _carRenderer[0].material = _carMateiral[_currentMaterialIndex];
            _carRenderer[1].material = _carMateiral[_currentMaterialIndex];
            _carRenderer[2].material = _carMateiral[_currentMaterialIndex];
            _carRenderer[3].material = _carMateiral[_currentMaterialIndex];
            _carRenderer[4].material = _carMateiral[_currentMaterialIndex];
        }
        else
        {
            Debug.Log("O renderer do carro nao foi atribuido");
        }
    }

    private void OnTurnOnTheCar()
    {
        if (!_theCarIsRunning)
        {
            _theCarIsRunning = true;
            _lightsCar.OnTurnOnAllLightsOfTheCar();
            Debug.Log($"the car is running");
            _frontRightHeadlightIsOn = true;
            _frontLeftHeadlightIsOn = true;
            _backRightHeadlightIsOn = true;
            _backLeftHeadlightIsOn = true;
            HandleAllHeadlightOn();
        }
        else
        {
            _theCarIsRunning = false;
            _lightsCar.OnTurnOffAllLightsOfTheCar();
            Debug.Log($"The car is off");
            _frontRightHeadlightIsOn = false;
            _frontLeftHeadlightIsOn = false;
            _backRightHeadlightIsOn = false;
            _backLeftHeadlightIsOn = false;
            HandleAllHeadlightOff();
        }
    }

    private void OnOpeningTheDoors()
    {
        if (_theDoorsAreOpen == false)
        {
            _theDoorsAreOpen = true;
            Debug.Log($"The doors are open");
        }
        else
        {
            _theDoorsAreOpen = false;
            Debug.Log($"The doors are close");
        }
    }

    private void OnTurnOnFrontRightHeadlight()
    {
        if (!_frontRightHeadlightIsOn)
        {
            _frontRightHeadlightIsOn = true;
            _lightsCar.OnTurnOnTheFrontRightLight();
            HandleFrontRightHeadlightOn();
            Debug.Log($"The front right headlight is on");
        }
        else
        {
            _frontRightHeadlightIsOn = false;
            _lightsCar.OnTurnOffTheFrontRightLight();
            HandleFrontRightHeadlightOff();
            Debug.Log($"The front right headlight is off");
        }
    }

    private void OnTurnOnFrontLeftHeadlight()
    {
        if (!_frontLeftHeadlightIsOn)
        {
            _frontLeftHeadlightIsOn = true;
            _lightsCar.OnTurnOnTheFrontLeftLight();
            HandleFrontLeftHeadlightOn();
            Debug.Log($"The front Left headlight is on");
        }
        else
        {
            _frontLeftHeadlightIsOn = false;
            _lightsCar.OnTurnOffTheFrontLeftLight();
            HandleFrontLeftHeadlightOff();
            Debug.Log($"The front Left headlight is off");
        }
    }

    private void OnTurnOnBackRightHeadlight()
    {
        if (!_backRightHeadlightIsOn)
        {
            _backRightHeadlightIsOn = true;
            _lightsCar.OnTurnOnTheBackRightLight();
            HandleBackRightHeadlightOn();
            Debug.Log($"The back right headlight is on");
        }
        else
        {
            _backRightHeadlightIsOn = false;
            _lightsCar.OnTurnOffTheBackRightLight();
            HandleBackRightHeadlightOff();
            Debug.Log($"The back right headlight is off");
        }
    }

    private void OnTurnOnBackLeftHeadlight()
    {
        if (!_backLeftHeadlightIsOn)
        {
            _backLeftHeadlightIsOn = true;
            _lightsCar.OnTurnOnTheBackLeftLight();
            HandleBackLeftHeadlightOn();
            Debug.Log($"The back left headlight is on");
        }
        else
        {
            _backLeftHeadlightIsOn = false;
            _lightsCar.OnTurnOffTheBackLeftLight();
            HandleBackLeftHeadlightOff();
            Debug.Log($"The back left headlight is off");
        }
    }

    private void HandleAllHeadlightOn()
    {
        _turnOnTheCarButton.image.color = Color.green;
        _turnOnTheCarText.text = "ON";
        HandleFrontRightHeadlightOn();
        HandleFrontLeftHeadlightOn();
        HandleBackRightHeadlightOn();
        HandleBackLeftHeadlightOn();
    }

    private void HandleAllHeadlightOff()
    {
        _turnOnTheCarButton.image.color = Color.red;
        _turnOnTheCarText.text = "OFF";
        HandleFrontRightHeadlightOff();
        HandleFrontLeftHeadlightOff();
        HandleBackRightHeadlightOff();
        HandleBackLeftHeadlightOff();
    }

    private void HandleFrontRightHeadlightOn()
    {
        _turnOnTheLightFrontRightButton.image.color = Color.green;
        _turnOnTheLightFrontRightText.text = "ON";
    }

    private void HandleFrontRightHeadlightOff()
    {
        _turnOnTheLightFrontRightButton.image.color = Color.red;
        _turnOnTheLightFrontRightText.text = "OFF";
    }

    private void HandleFrontLeftHeadlightOn()
    {
        _turnOnTheLightFrontLeftButton.image.color = Color.green;
        _turnOnTheLightFrontLeftText.text = "ON";
    }

    private void HandleFrontLeftHeadlightOff()
    {
        _turnOnTheLightFrontLeftButton.image.color = Color.red;
        _turnOnTheLightFrontLeftText.text = "OFF";
    }

    private void HandleBackRightHeadlightOn()
    {
        _turnOnTheLightBackRightButton.image.color = Color.green;
        _turnOnTheLightBackRightText.text = "ON";
    }

    private void HandleBackRightHeadlightOff()
    {
        _turnOnTheLightBackRightButton.image.color = Color.red;
        _turnOnTheLightBackRightText.text = "OFF";
    }

    private void HandleBackLeftHeadlightOn()
    {
        _turnOnTheLightBackLeftButton.image.color = Color.green;
        _turnOnTheLightBackLeftText.text = "ON";
    }

    private void HandleBackLeftHeadlightOff()
    {
        _turnOnTheLightBackLeftButton.image.color = Color.red;
        _turnOnTheLightBackLeftText.text = "OFF";
    }
}