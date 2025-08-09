using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float defaultFov = 75f;
    [SerializeField] float zoomFov = 30f;
    [SerializeField] float zoomSpeed = 20f;
    float currentFov;
    bool isZooming;

    void Start()
    {
        currentFov = defaultFov;
    }

    void Update()
    {
        ZoomInput();
        HandleZoom();
    }

    private void ZoomInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZooming = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isZooming = false;
        }

    }

    private void HandleZoom()
    {
        if (isZooming)
        {
            currentFov = Mathf.MoveTowards(currentFov, zoomFov, zoomSpeed * Time.deltaTime);
        }
        else
        {
            currentFov = Mathf.MoveTowards(currentFov, defaultFov, zoomSpeed * Time.deltaTime);
        }
        playerCamera.fieldOfView = currentFov;
    }
}
