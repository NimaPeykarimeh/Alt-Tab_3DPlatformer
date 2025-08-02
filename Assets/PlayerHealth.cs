using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField]int currentHealth;
    Vector3 startingPosition;
    [SerializeField] Rigidbody rb;
    [SerializeField] float pushForce = 1f;

    [SerializeField] float fallLimit = -5f;
    private void Start()
    {
        currentHealth = maxHealth;
        startingPosition = transform.position;
    }

    private void Update()
    {
        CheckFall();
    }

    private void CheckFall()
    {
        if (transform.position.y <= fallLimit)
        {
            PlayerDead();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector3 pushDirection = collision.contacts[0].normal;
            rb.AddForce(pushDirection * pushForce,ForceMode.Impulse);
            TakeDamage();
        }
    }

    public void SetStartingPosition()
    {
        startingPosition = transform.position;
    }

    private void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        transform.position = startingPosition;
        currentHealth = maxHealth;
    }
}
