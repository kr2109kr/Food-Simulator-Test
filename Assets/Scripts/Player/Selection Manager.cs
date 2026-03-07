using UnityEngine;
using UnityEngine.InputSystem;

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


    [SerializeField] private PlayerEquipment _playerEquipment;


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

    private void OnTouchPress(InputAction.CallbackContext context)
    {
        Ray ray = _camera.ScreenPointToRay(_currentTouchPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _oldPosition = hit.transform.position;

            _selectedObject = hit.transform;
            _dragPlane = new Plane(-_camera.transform.forward, hit.point);
            _offset = _selectedObject.position - hit.point;
 
            //var T = hit.transform.GetComponent<Equipment>();
            //Debug.Log(T);

            CheckRayForEquipment(hit);
            CheckRayForStation(hit);

            CheckForInteract(hit);
        }
    }


    private void CheckRayForEquipment(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<Equipment>(out var equipment))
        {
            _playerEquipment.Equip(equipment);
        }
    }

    private void CheckRayForStation(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<Station>(out var station) && _playerEquipment.HasEqupment)
        {
            _playerEquipment.UnEquip();
        }
    }

    private void CheckForInteract(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<IInteractor>(out var interactor))
        {
            interactor.Interact(_playerEquipment.GetEquipment());
        }
    }

    public void TakeEquipment()
    {
        if (_playerEquipment.GetEquipment())
        {
            var t = _playerEquipment.GetEquipment().transform;
            Ray ray = _camera.ScreenPointToRay(_currentTouchPos);



            if (_dragPlane.Raycast(ray, out float distance))
            {
                t.position = ray.GetPoint(distance) + _offset;
            }

        }


    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _currentTouchPos = context.ReadValue<Vector2>();

        TakeEquipment();

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
            if (hits[1].transform.gameObject.TryGetComponent<Customer>(out Customer customer1))
            {
                //customer1.CheckOrder(_taiyakiFilling);
            }
            

            var customer = hits[1].transform.gameObject;
        }
    }
}
