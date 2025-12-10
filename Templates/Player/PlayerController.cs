using UnityEngine;
using UnityEngine.InputSystem;
using Player;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerControllerSettings _settings;
    
    [Header("Components")]
    [SerializeField]
    private CharacterController _characterController;
    
    // Input Action references
    private InputAction _moveAction;
    private InputAction _jumpAction;
    
    // Movement variables
    private Vector2 _moveInput;
    private Vector3 _velocity;

    private void Awake()
    {
        // Get CharacterController if not assigned
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }
    }

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        // Find the references to the "Move" and "Jump" actions
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        HandleGrounding();
        HandleInput();
        Move();
        ApplyGravity();
    }

    void HandleGrounding()
    {
        // Reset vertical velocity when grounded to prevent accumulation
        if (_characterController.isGrounded && _velocity.y < 0)
        {
            // Small downward force to keep character "stuck" to ground
            _velocity.y = _settings != null ? _settings.groundingForce : -2f;
        }
    }

    void HandleInput()
    {
        // Read the "Move" action value (2D vector)
        _moveInput = _moveAction.ReadValue<Vector2>();
        
        // Handle jump input
        if (_jumpAction.triggered && _characterController.isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        if (_settings == null) return;
        
        // Calculate movement direction based on input
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
        
        // Apply movement speed
        Vector3 movement = moveDirection * (_settings.moveSpeed * Time.deltaTime);
        
        // Move the character
        _characterController.Move(movement);
    }

    void Jump()
    {
        // Calculate jump velocity using: v = sqrt(h * -2 * g)
        _velocity.y = Mathf.Sqrt(_settings.jumpHeight * -2f * _settings.gravity);
    }

    void ApplyGravity()
    {
        // Apply gravity
        _velocity.y += _settings.gravity * Time.deltaTime;
        
        // Apply vertical velocity
        _characterController.Move(_velocity * Time.deltaTime);
    }
}