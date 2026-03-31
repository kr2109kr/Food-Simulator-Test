using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float xRotation = 0f;

    [SerializeField] private float _xSentivity = 30f;
    [SerializeField] private float _ySentivity = 30f;

    [Header("Input References")]
    public InputActionReference _mouseMovement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        _mouseMovement.action.Enable();
        _mouseMovement.action.performed += OnMousePosition; 
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        ProcessLook(context.ReadValue<Vector2>());
        //Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        Debug.Log("Destroyed");
    }

    

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * _ySentivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //apply this to our camera transform
        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player to look left and right


        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSentivity);
        
    }
}
