using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    // Kamera bileşeni ve zoom ayarları için değişkenler
    [SerializeField] Camera playerCamera; // Oyuncunun kamerası
    [SerializeField] float defaultFov = 75f; // Varsayılan görüş açısı (Field of View)
    [SerializeField] float zoomFov = 30f; // Yakınlaştırma sırasında görüş açısı
    [SerializeField] float zoomSpeed = 20f; // Yakınlaştırma hızı
    float currentFov; // Şu anki görüş açısı
    bool isZooming; // Yakınlaştırma yapılıp yapılmadığını kontrol eder

    void Start()
    {
        // Başlangıçta görüş açısını varsayılan değere ayarla
        currentFov = defaultFov;
    }

    void Update()
    {
        // Her karede kullanıcı girişini ve yakınlaştırmayı kontrol et
        ZoomInput();
        HandleZoom();
    }

    private void ZoomInput()
    {
        // Sağ fare tuşuna basıldığında yakınlaştırmayı başlat
        if (Input.GetMouseButtonDown(1))
        {
            isZooming = true;
        }
        // Sağ fare tuşu bırakıldığında yakınlaştırmayı durdur
        else if (Input.GetMouseButtonUp(1))
        {
            isZooming = false;
        }

    }

    private void HandleZoom()
    {
        // Yakınlaştırma yapılıyorsa görüş açısını zoomFov değerine doğru değiştir
        if (isZooming)
        {
            currentFov = Mathf.MoveTowards(currentFov, zoomFov, zoomSpeed * Time.deltaTime);
        }
        // Yakınlaştırma yapılmıyorsa görüş açısını varsayılan değere doğru değiştir
        else
        {
            currentFov = Mathf.MoveTowards(currentFov, defaultFov, zoomSpeed * Time.deltaTime);
        }
        // Kameranın görüş açısını güncelle
        playerCamera.fieldOfView = currentFov;
    }
}
