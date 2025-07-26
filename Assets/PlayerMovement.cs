using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[HideInInspector] public float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    [SerializeField] float jumpSpeed;
    [SerializeField] bool isGrounded;

    private void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontalMove, 0f, verticalMove).normalized * speed;


        float yVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumpSpeed;
            isGrounded = false;
        }
        else
        {
            yVelocity = rb.linearVelocity.y;
        }

        Vector3 velocity = new Vector3(move.x,yVelocity,move.z) ;

        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.tag == "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }
}
