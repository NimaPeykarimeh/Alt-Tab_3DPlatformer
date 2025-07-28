using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun fiziksel hareketlerini kontrol etmek için Rigidbody bileþeni
    [SerializeField] private Rigidbody rb;

    // Yerdeyken hareket hýzý
    [SerializeField] private float speed = 5f;

    // Zýplama hýzý (yani yukarý doðru ne kadar güçlü zýplanacaðý)
    [SerializeField] private float jumpSpeed = 5f;

    // Oyuncu þu anda yerde mi? Bunu kontrol ederiz ki sadece yerdeyken zýplasýn
    [SerializeField] private bool isGrounded;

    private void Update()
    {
        // Yön tuþlarýna veya WASD'ye basýldýðýnda alýnan giriþ
        float horizontalMove = Input.GetAxisRaw("Horizontal"); // A-D veya Sol-Sað
        float verticalMove = Input.GetAxisRaw("Vertical");     // W-S veya Ýleri-Geri

        // Hareket yönü (x ve z ekseni) ve hýz çarpýmý
        Vector3 move = new Vector3(horizontalMove, 0f, verticalMove).normalized * speed;

        float yVelocity;

        // Space tuþuna basýlýrsa ve oyuncu yerdeyse zýplama baþlar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumpSpeed; // yukarý doðru hýz ver
            isGrounded = false;    // artýk havadayýz
        }
        else
        {
            yVelocity = rb.linearVelocity.y; // y ekseni hýzýný koru (örneðin düþerken)
        }

        // Yeni hýz vektörü (x ve z ekseni için hareket + y ekseni için zýplama/düþme)
        Vector3 velocity = new Vector3(move.x, yVelocity, move.z);

        // Rigidbody'nin hýzýný ayarla (karakteri hareket ettir)
        rb.linearVelocity = velocity;
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
