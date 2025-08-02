using UnityEngine;

public class MovingObject : MonoBehaviour
{

    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    Transform targetPoint;

    private void Start()
    {
        targetPoint = point1;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.1f)
        {
            if (targetPoint == point1)
            {
                targetPoint = point2;
            }
            else
            {
                targetPoint = point1;
            }
        }

        Vector3 moveDirection = (targetPoint.position - transform.position).normalized;
        Vector3 newPosition = transform.position + moveDirection * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);

    }

}
