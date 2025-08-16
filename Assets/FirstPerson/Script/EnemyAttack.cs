using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int attackDamage = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Destroy(gameObject);
        }
    }
}
