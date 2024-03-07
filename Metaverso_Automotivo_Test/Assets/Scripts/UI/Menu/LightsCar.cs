using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsCar : MonoBehaviour
{
    [SerializeField] private GameObject _lightFrontRight;
    [SerializeField] private GameObject _lightFrontLeft;
    [SerializeField] private GameObject _lightBackOneRight;
    [SerializeField] private GameObject _lightBackTwoRight;
    [SerializeField] private GameObject _lightBackOneLeft;
    [SerializeField] private GameObject _lightBackTwoLeft;

    public void OnTurnOnAllLightsOfTheCar()
    {
        _lightFrontRight.SetActive(true);
        _lightFrontLeft.SetActive(true);
        _lightBackOneRight.SetActive(true);
        _lightBackTwoRight.SetActive(true);
        _lightBackOneLeft.SetActive(true);
        _lightBackTwoLeft.SetActive(true);
    }

    public void OnTurnOffAllLightsOfTheCar()
    {
        _lightFrontRight.SetActive(false);
        _lightFrontLeft.SetActive(false);
        _lightBackOneRight.SetActive(false);
        _lightBackTwoRight.SetActive(false);
        _lightBackOneLeft.SetActive(false);
        _lightBackTwoLeft.SetActive(false);
    }

    public void OnTurnOnTheFrontRightLight()
    {
        _lightFrontRight.SetActive(true);
    }
    
    public void OnTurnOffTheFrontRightLight()
    {
        _lightFrontRight.SetActive(false);
    }
    
    public void OnTurnOnTheFrontLeftLight()
    {
        _lightFrontLeft.SetActive(true);
    }
    
    public void OnTurnOffTheFrontLeftLight()
    {
        _lightFrontLeft.SetActive(false);
    }
    
    public void OnTurnOnTheBackRightLight()
    {
        _lightBackOneRight.SetActive(true);
        _lightBackTwoRight.SetActive(true);
    }
    
    public void OnTurnOffTheBackRightLight()
    {
        _lightBackOneRight.SetActive(false);
        _lightBackTwoRight.SetActive(false);
    }
    
    public void OnTurnOnTheBackLeftLight()
    {
        _lightBackOneLeft.SetActive(true);
        _lightBackTwoLeft.SetActive(true);
    }
    
    public void OnTurnOffTheBackLeftLight()
    {
        _lightBackOneLeft.SetActive(false);
        _lightBackTwoLeft.SetActive(false);
    }
}
