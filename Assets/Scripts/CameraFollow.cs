using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Takip edilecek oyuncunun Transform'u (pozisyon, dönüþ, ölçek bilgisi)
    [SerializeField] Transform playerTransform;

    // Kameranýn oyuncuya göre ne kadar uzakta duracaðýný belirler (x, y, z)
    [SerializeField] Vector3 followOffset;

    // Oyuncunun hareketinden sonra çalýþýr, kamera güncellenir
    void LateUpdate()
    {
        // Kameranýn pozisyonu = oyuncunun pozisyonu + ofset (uzaklýk)
        transform.position = playerTransform.position + followOffset;
    }
}
