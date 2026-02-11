using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    
    [Header("Jump")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;
    
    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;
    private bool isGrounded;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        checkGrounded();

        // Movimiento
        MovePlayer();
        
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void checkGrounded()
    {
        // Verificar si está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantener pegado al suelo
        }
    }

    private void MovePlayer()
    {
        // Calcular dirección de movimiento
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        
        if (move.magnitude > 0.1f)
        {
            // Mover el player
            controller.Move(move * moveSpeed * Time.deltaTime);
            
            // Rotar hacia la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
    }
    
    // Llamado por el Input System
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    // Llamado por el Input System
    public void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}