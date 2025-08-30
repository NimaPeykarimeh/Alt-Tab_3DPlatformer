using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] GameObject destroyParticlePrefab;
    public void DestroyObject()
    {
        Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
