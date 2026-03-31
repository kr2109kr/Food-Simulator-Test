using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;

    
    [SerializeField] private float _speed = 10f;

    [Header("Input References")]
    public InputActionReference _playerMovement;


    private void OnEnable()
    {
        _playerMovement.action.Enable();
        _playerMovement.action.performed += OnMovement;
    }

    private void OnDisable()
    {
        _playerMovement.action.Disable();
        _playerMovement.action.performed -= OnMovement;
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        
        
    }

    private void Update()
    {
        ProcessMove(_playerMovement.action.ReadValue<Vector2>());
    }


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _characterController.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
    }
}
