using UnityEngine;

public class HitDetection : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float rayDistance = 100f;

    [SerializeField] GameObject hitParticlePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DetectHit();
        }
    }

    private void DetectHit()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.forward, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyHealth>().DestroyObject();
            }
            //Instantiate(hitParticlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject _particleObject = Instantiate(hitParticlePrefab, hit.point, Quaternion.identity);
            _particleObject.transform.forward = hit.normal;
        }
    }
}
