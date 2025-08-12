using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    // Oyuncunun hareketi ve fiziksel etkileşimleri için değişkenler
    [SerializeField] float moveSpeed = 4f; // Hareket hızı
    CharacterController characterController; // Karakter kontrol bileşeni

    [SerializeField] float gravity = -9.81f; // Yerçekimi kuvveti
    [SerializeField] float jumpHeight = 1.5f; // Zıplama yüksekliği
    float verticalSpeed = 0f; // Dikey hız (zıplama ve düşme için)

    [SerializeField] float raycastDistance = 1.1f; // Yere temas kontrolü için ışın mesafesi
    [SerializeField] LayerMask groundLayer; // Zemin katmanı

    bool isGrounded; // Oyuncunun zeminde olup olmadığını kontrol eder

    void Start()
    {
        // Karakter kontrol bileşenini al
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Her karede zeminde olup olmadığını ve hareketi kontrol et
        IsGrounded();
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Kullanıcıdan hareket girişlerini al
        float inputZ = Input.GetAxisRaw("Vertical"); // İleri-geri hareket
        float inputX = Input.GetAxisRaw("Horizontal"); // Sağ-sol hareket

        // Hareket yönünü hesapla
        Vector3 moveDirection = (transform.right * inputX + transform.forward * inputZ).normalized;

        if (isGrounded)
        {
            // Zıplama girişini kontrol et
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Düşüş hızını sıfırla
            if (verticalSpeed < 0)
            {
                verticalSpeed = -2f; 
            }
        }
        // Yerçekimi etkisini uygula
        verticalSpeed += gravity * Time.deltaTime;

        // Hareket vektörünü oluştur ve uygula
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        movement.y = verticalSpeed * Time.deltaTime;
        characterController.Move(movement);
    }

    private void IsGrounded()
    {
        // Zemine temas kontrolü için ışın kullan
        if (Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
