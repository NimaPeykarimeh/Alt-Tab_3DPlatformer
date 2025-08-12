using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    // Fare hareketi ile kamerayı döndürmek için değişkenler
    [SerializeField] float mouseSensitivity = 2f; // Fare hassasiyeti
    [SerializeField] Transform cameraTransform; // Kameranın transform bileşeni

    float xRotation = 0f; // Kameranın dikey eksendeki dönüş açısı

    void Start()
    {
        // Fare imlecini kilitle ve görünmez yap
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Her karede fare hareketlerini kontrol et
        MouseLookHorizontal();
        MouseLookVertical();
    }

    private void MouseLookHorizontal()
    {
        // Fare X ekseni hareketini al ve yatay dönüş uygula
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void MouseLookVertical()
    {
        // Fare Y ekseni hareketini al ve dikey dönüş uygula
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;

        // Dikey dönüş açısını sınırla
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Kameranın dikey dönüşünü güncelle
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
