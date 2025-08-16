using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float rayDistance = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectEnemy();
        }
    }

    private void DetectEnemy()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.forward,out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);

            }
        }
    }
}
