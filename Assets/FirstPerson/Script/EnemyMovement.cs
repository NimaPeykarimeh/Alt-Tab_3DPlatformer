using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] float speed = 2f;
    [SerializeField] float minDistance = 1f;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; �al���r, ama biraz daha az optimize
    }
    private void Update()
    {
        FollowPlayer();
    }

    public void SetPlayer(Transform playerReference)
    {
        playerTransform = playerReference;
    }

    private void FollowPlayer()
    {
        // if (Vector3.Distance(transform.position,playerTransform.position) > minDistance)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        //     transform.LookAt(playerTransform);
        // }
        navMeshAgent.SetDestination(playerTransform.position);
    }
}
