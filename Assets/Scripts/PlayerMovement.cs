using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun fiziksel hareketlerini kontrol etmek için Rigidbody bileþeni
    [SerializeField] private Rigidbody rb;

    // Yerdeyken hareket hýzý
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float moveForce = 15f;

    // Zýplama hýzý (yani yukarý doðru ne kadar güçlü zýplanacaðý)
    [SerializeField] private float jumpForce  = 5f;

    // Oyuncu þu anda yerde mi? Bunu kontrol ederiz ki sadece yerdeyken zýplasýn
    [SerializeField] private bool isGrounded;

    private void Update()
    {
        // Yön tuþlarýna veya WASD'ye basýldýðýnda alýnan giriþ
        float horizontalMove = Input.GetAxisRaw("Horizontal"); // A-D veya Sol-Sað
        float verticalMove = Input.GetAxisRaw("Vertical");     // W-S veya Ýleri-Geri

        // Hareket yönü (x ve z ekseni) ve hýz çarpýmý
        Vector3 moveInput = new Vector3(horizontalMove, 0f, verticalMove).normalized ;

        Vector3 force = moveInput * moveForce;

        rb.AddForce(force);

        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }


        // Space tuþuna basýlýrsa ve oyuncu yerdeyse zýplama baþlar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
            isGrounded = false;    // artýk havadayýz
        }


    }

    // Bir yere çarpýldýðýnda çaðrýlýr
    private void OnCollisionEnter(Collision collision)
    {
        // Eðer yere çarptýysak (Ground etiketi varsa), yerdeyiz
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Yerden ayrýldýðýmýzda (havaya zýpladýðýmýzda) çaðrýlýr
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
