using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Oyuncunun fiziksel hareketlerini kontrol etmek i�in Rigidbody bile�eni
    [SerializeField] private Rigidbody rb;

    // Yerdeyken hareket h�z�
    [SerializeField] private float speed = 5f;

    // Z�plama h�z� (yani yukar� do�ru ne kadar g��l� z�planaca��)
    [SerializeField] private float jumpSpeed = 5f;

    // Oyuncu �u anda yerde mi? Bunu kontrol ederiz ki sadece yerdeyken z�plas�n
    [SerializeField] private bool isGrounded;

    private void Update()
    {
        // Y�n tu�lar�na veya WASD'ye bas�ld���nda al�nan giri�
        float horizontalMove = Input.GetAxisRaw("Horizontal"); // A-D veya Sol-Sa�
        float verticalMove = Input.GetAxisRaw("Vertical");     // W-S veya �leri-Geri

        // Hareket y�n� (x ve z ekseni) ve h�z �arp�m�
        Vector3 move = new Vector3(horizontalMove, 0f, verticalMove).normalized * speed;

        float yVelocity;

        // Space tu�una bas�l�rsa ve oyuncu yerdeyse z�plama ba�lar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumpSpeed; // yukar� do�ru h�z ver
            isGrounded = false;    // art�k havaday�z
        }
        else
        {
            yVelocity = rb.linearVelocity.y; // y ekseni h�z�n� koru (�rne�in d��erken)
        }

        // Yeni h�z vekt�r� (x ve z ekseni i�in hareket + y ekseni i�in z�plama/d��me)
        Vector3 velocity = new Vector3(move.x, yVelocity, move.z);

        // Rigidbody'nin h�z�n� ayarla (karakteri hareket ettir)
        rb.linearVelocity = velocity;
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
