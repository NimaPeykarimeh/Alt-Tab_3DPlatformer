using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 followOffset;
    

    
    void LateUpdate()
    {
        transform.position = playerTransform.position + followOffset;
    }
}
