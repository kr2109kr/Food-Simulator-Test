using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _cookingVirtualCams;
    [SerializeField] private CinemachineVirtualCamera[] _cashierVirtualCams;

    [SerializeField] private CinemachineBrain _brain;
    private int _currentCookingCam;
    private int _currentCashierCam;
    private bool _isInCookingSection = true;


    [Header("Input References")]
    public InputActionReference _switchUpAction;
    public InputActionReference _switchDownAction;
    public InputActionReference _switchLeftAction;
    public InputActionReference _switchRightAction;

    private void OnEnable()
    {
        _switchUpAction.action.Enable();
        _switchDownAction.action.Enable();
        _switchLeftAction.action.Enable();
        _switchRightAction.action.Enable();

        _switchUpAction.action.performed += SwitchToCookingSection;
        _switchDownAction.action.performed += SwitchToCounterSection;
        _switchLeftAction.action.performed += SwitchToPreviousCamera;
        _switchRightAction.action.performed += SwitchToNextCamera;
    }

    private void Start()
    {
        foreach (CinemachineVirtualCamera cam in _cookingVirtualCams)
        {
            cam.Priority = 0;
        }

        foreach (CinemachineVirtualCamera cam in _cashierVirtualCams)
        {
            cam.Priority = 0;
        }

        _cookingVirtualCams[_currentCookingCam].Priority = 10;
    }

    private void SwitchToCookingSection(InputAction.CallbackContext obj)
    {
        if (!_isInCookingSection)
        {
            foreach (CinemachineVirtualCamera cam in _cashierVirtualCams)
            {
                cam.Priority = 0;
            }

            _cookingVirtualCams[_currentCookingCam].Priority = 10;

            _isInCookingSection = true;
        }
    }

    private void SwitchToCounterSection(InputAction.CallbackContext context)
    {
        if (_isInCookingSection)
        {
            foreach (CinemachineVirtualCamera cam in _cookingVirtualCams)
            {
                cam.Priority = 0;
            }

            _cashierVirtualCams[_currentCashierCam].Priority = 10;

            _isInCookingSection = false;
        }
    }

    public void SwitchToPreviousCamera(InputAction.CallbackContext context)
    {
        if (_isInCookingSection)
        {
            _cookingVirtualCams[_currentCookingCam].Priority = 0;
            _currentCookingCam = (_currentCookingCam - 1 + _cookingVirtualCams.Length) % _cookingVirtualCams.Length;
            _cookingVirtualCams[_currentCookingCam].Priority = 1;
        }
    }

    public void SwitchToNextCamera(InputAction.CallbackContext context)
    {
        if (_isInCookingSection)
        {
            _cookingVirtualCams[_currentCookingCam].Priority = 0;
            _currentCookingCam = (_currentCookingCam + 1) % _cookingVirtualCams.Length;
            _cookingVirtualCams[_currentCookingCam].Priority = 1;
        }
    }

    public bool IsCameraSwitching()
    {
        if (_brain.IsBlending)
        {
            return true;
        }
        return false;
    }
}
