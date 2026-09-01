using CustomerSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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


    [SerializeField] private Player _player;

    //[SerializeField] private CameraSwitch _cameraSwitch;


    private void OnDrawGizmos()
    {
        
    }

    private void OnEnable()
    {
        _trackingPoint.action.Enable();
        _clickingAction.action.Enable();

        _trackingPoint.action.performed += OnTouchPosition;
        _trackingPoint.action.performed += OnMousePosition;


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

    private void Update()
    {
        RaycatOutline();
    }

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            /*
            _oldPosition = hit.transform.position;

            _selectedObject = hit.transform;
            _dragPlane = new Plane(-_camera.transform.forward, hit.point);
            _offset = _selectedObject.position - hit.point;
            */

            CheckForInteract(hit);
        }
    }

    private void CheckForInteract(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<IInteractor>(out var interactor) && _player.IsInteracting == false)
        {
            interactor.Interact(_player);
        }
    }

    

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _currentTouchPos = context.ReadValue<Vector2>();
        Debug.Log("www");
        
    }

    private Test current;

    private void RaycatOutline()
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);


        //Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Test newTarget = hit.collider.GetComponent<Test>();

            if (newTarget != current)
            {
                if (current != null)
                    current.DisableOutline();

                current = newTarget;

                if (current != null)
                    current.EnableOutline();
            }
        }
        else
        {
            if (current != null)
            {
                current.EnableOutline();
                current = null;
            }
        }
    }

    private void OnTouchRelease(InputAction.CallbackContext context)
    {
        //CheckRaycastTarget();

        if (_selectedObject != null)
        {
            _selectedObject.position = _oldPosition;
        }
        
        _selectedObject = null;
    }

    private void OnTouchPosition(InputAction.CallbackContext context)
    {

        _currentTouchPos = context.ReadValue<Vector2>();

        /*
        if (_selectedObject != null)
        {
            Ray ray = _camera.ScreenPointToRay( _currentTouchPos );
            if (_dragPlane.Raycast(ray, out float distance))
            {
                _selectedObject.position = ray.GetPoint(distance) + _offset;
            }
        }
        */
    }



    private void CheckRaycastTarget()
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        System.Array.Sort(hits, (a, b) => (a.distance.CompareTo(b.distance)));

        if (hits.Length > 1)
        {
            if (hits[1].transform.gameObject.TryGetComponent<CustomerOrder>(out CustomerOrder customer1))
            {
                //customer1.CheckOrder(_taiyakiFilling);
            }
            

            var customer = hits[1].transform.gameObject;
        }
    }
}
