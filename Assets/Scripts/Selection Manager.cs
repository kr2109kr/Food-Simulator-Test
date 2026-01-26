using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class SelectionManager : MonoBehaviour
{
    [Header("Input References")]
    public InputActionReference _trackingPoint;
    public InputActionReference _clickingAction;

    [Header("Camera Reference")]
    [SerializeField] private Camera _camera;

    private Vector2 _currentTouchPos;
    private Transform _selectedObject;
    private Vector3 _offset;
    private Plane _dragPlane;

    private Vector3 _oldPosition;
    private void OnEnable()
    {
        _trackingPoint.action.Enable();
        _clickingAction.action.Enable();

        _trackingPoint.action.performed += OnTouchPosition;
        _clickingAction.action.performed += OnTouchPress;
        _clickingAction.action.canceled += OnTouchRelease;
    }

    private void OnDisable()
    {
        _trackingPoint.action.performed -= OnTouchPosition;
        _clickingAction.action.performed -= OnTouchPress;
        _clickingAction.action.canceled -= OnTouchRelease;

        _trackingPoint.action.Disable();
        _clickingAction.action.Disable();
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _oldPosition = hit.transform.position;

            _selectedObject = hit.transform;
            _dragPlane = new Plane(-_camera.transform.forward, hit.point);
            _offset = _selectedObject.position - hit.point;
        }
    }

    private void OnTouchRelease(InputAction.CallbackContext context)
    {
        CheckRaycastTarget();

        if (_selectedObject != null)
        {
            _selectedObject.position = _oldPosition;
        }
        
        _selectedObject = null;
    }

    private void OnTouchPosition(InputAction.CallbackContext context)
    {
        _currentTouchPos = context.ReadValue<Vector2>();

        if (_selectedObject != null)
        {
            Ray ray = _camera.ScreenPointToRay( _currentTouchPos );
            if (_dragPlane.Raycast(ray, out float distance))
            {
                _selectedObject.position = ray.GetPoint(distance) + _offset;
            }
        }
    }

    private void CheckRaycastTarget()
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        System.Array.Sort(hits, (a, b) => (a.distance.CompareTo(b.distance)));

        if (hits.Length > 1)
        {
            if (hits[1].transform.gameObject.TryGetComponent<Customer>(out Customer customer1))
            {
                Debug.Log("Hello");
            }
            

            var customer = hits[1].transform.gameObject;
            Debug.Log("Detected : " + hits[1].transform.gameObject.name);
        }
    }
}
