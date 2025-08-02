using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun fiziksel hareketlerini kontrol etmek i�in Rigidbody bile�eni
    [SerializeField] private Rigidbody rb;

    // Yerdeyken hareket h�z�
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float moveForce = 15f;

    // Z�plama h�z� (yani yukar� do�ru ne kadar g��l� z�planaca��)
    [SerializeField] private float jumpForce  = 5f;

    // Oyuncu �u anda yerde mi? Bunu kontrol ederiz ki sadece yerdeyken z�plas�n
    [SerializeField] private bool isGrounded;

    private void Update()
    {
        // Y�n tu�lar�na veya WASD'ye bas�ld���nda al�nan giri�
        float horizontalMove = Input.GetAxisRaw("Horizontal"); // A-D veya Sol-Sa�
        float verticalMove = Input.GetAxisRaw("Vertical");     // W-S veya �leri-Geri

        // Hareket y�n� (x ve z ekseni) ve h�z �arp�m�
        Vector3 moveInput = new Vector3(horizontalMove, 0f, verticalMove).normalized ;

        Vector3 force = moveInput * moveForce;

        rb.AddForce(force);

        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }


        // Space tu�una bas�l�rsa ve oyuncu yerdeyse z�plama ba�lar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isGrounded = false;    // art�k havaday�z
        }


    }

    // Bir yere �arp�ld���nda �a�r�l�r
    private void OnCollisionEnter(Collision collision)
    {
        // E�er yere �arpt�ysak (Ground etiketi varsa), yerdeyiz
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Yerden ayr�ld���m�zda (havaya z�plad���m�zda) �a�r�l�r
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
