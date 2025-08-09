using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    CharacterController characterController;

    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 1.5f;
    float verticalSpeed = 0f;

    [SerializeField] float raycastDistance = 1.1f;
    [SerializeField] LayerMask groundLayer;

    bool isGrounded;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        IsGrounded();
        MovePlayer();
    }

    private void MovePlayer()
    {
        float inputZ = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = (transform.right * inputX + transform.forward * inputZ).normalized;

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (verticalSpeed < 0)
            {
                verticalSpeed = -2f; 
            }
        }
        verticalSpeed += gravity * Time.deltaTime;

        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        movement.y = verticalSpeed * Time.deltaTime;
        characterController.Move(movement);
        
    }

    private void IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        //isGrounded = Physics.CheckSphere(transform.position, raycastDistance, groundLayer);
    }
}
