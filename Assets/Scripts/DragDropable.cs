using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropable : MonoBehaviour
{
    [SerializeField] private InputAction press, screenPos;

    private Vector3 _curScreenPos;

    Camera _mainCamera;


    private bool _isDragging;

    private Vector3 WorldPos
    {
        get
        {
            float z = _mainCamera.WorldToScreenPoint(transform.position).z;
            return _mainCamera.ScreenToWorldPoint(_curScreenPos + new Vector3(0, 0, z));
        }
    }

    private bool isClickedOn
    {
        get
        {
            Ray ray = _mainCamera.ScreenPointToRay(_curScreenPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }
    }

    private void Awake()
    {
        press.Enable();
        screenPos.Enable();
        screenPos.performed += context => { _curScreenPos = context.ReadValue<Vector2>(); };


        press.performed += _ => { if(isClickedOn) StartCoroutine(Drag()); };
        press.canceled += _ => { _isDragging = false; };

    }
    
    private IEnumerator Drag()
    {
        _isDragging = true;
        Vector3 offset = transform.position - WorldPos;
        // grab
        while (_isDragging)
        {
            // dragging
            transform.position = WorldPos + offset;
            yield return null;
        }
        // drop
    }

    private void Press_performed(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
