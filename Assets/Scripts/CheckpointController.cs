using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            playerHealth.SetStartingPosition();
        }
    }
}
