using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Takip edilecek oyuncunun Transform'u (pozisyon, d�n��, �l�ek bilgisi)
    [SerializeField] Transform playerTransform;

    // Kameran�n oyuncuya g�re ne kadar uzakta duraca��n� belirler (x, y, z)
    [SerializeField] Vector3 followOffset;

    // Oyuncunun hareketinden sonra �al���r, kamera g�ncellenir
    void LateUpdate()
    {
        // Kameran�n pozisyonu = oyuncunun pozisyonu + ofset (uzakl�k)
        transform.position = playerTransform.position + followOffset;
    }
}
