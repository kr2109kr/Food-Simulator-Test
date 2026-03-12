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

    private int currentCookingCam;
    private int currentCashierCam;
    private bool isInCookingSection = true;


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

        _cookingVirtualCams[currentCookingCam].Priority = 10;
    }

    private void SwitchToCookingSection(InputAction.CallbackContext obj)
    {
        if (!isInCookingSection)
        {
            foreach (CinemachineVirtualCamera cam in _cashierVirtualCams)
            {
                cam.Priority = 0;
            }

            _cookingVirtualCams[currentCookingCam].Priority = 10;

            isInCookingSection = true;
        }
    }

    private void SwitchToCounterSection(InputAction.CallbackContext context)
    {
        if (isInCookingSection)
        {
            foreach (CinemachineVirtualCamera cam in _cookingVirtualCams)
            {
                cam.Priority = 0;
            }

            _cashierVirtualCams[currentCashierCam].Priority = 10;

            isInCookingSection = false;
        }
    }

    public void SwitchToPreviousCamera(InputAction.CallbackContext context)
    {
        _cookingVirtualCams[currentCookingCam].Priority = 0;
        currentCookingCam = (currentCookingCam - 1 + _cookingVirtualCams.Length) % _cookingVirtualCams.Length;
        _cookingVirtualCams[currentCookingCam].Priority = 1;
    }

    public void SwitchToNextCamera(InputAction.CallbackContext context)
    {
        _cookingVirtualCams[currentCookingCam].Priority = 0;
        currentCookingCam = (currentCookingCam + 1) % _cookingVirtualCams.Length;
        _cookingVirtualCams[currentCookingCam].Priority = 1;
    }
}
