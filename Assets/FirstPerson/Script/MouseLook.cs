using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] Transform cameraTransform;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MouseLookHorizontal();
        MouseLookVertical();
    }
    private void MouseLookHorizontal()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void MouseLookVertical()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation,-80f,80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }
}
