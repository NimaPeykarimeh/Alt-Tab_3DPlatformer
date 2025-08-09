using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float inputZ = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = (transform.right * inputX + transform.forward * inputZ).normalized;
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
