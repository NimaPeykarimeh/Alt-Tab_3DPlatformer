using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform playerTransform;
    [SerializeField] float minDistanceToPlayer = 5f;
    [SerializeField] float maxDistanceToPlayer = 15f;

    [SerializeField] float spawnRange = 25f;

    [SerializeField] float startingSpawnTime = 5f;
    [SerializeField] float spawnTimeReduce = 0.1f;
    [SerializeField] float minimumSpawnTime = 0.7f;

    [Header("Debug")]
    [SerializeField] private float currentSpawnTime;
    [SerializeField] private float spawnTimer;

    private void Start()
    {
        currentSpawnTime = startingSpawnTime;
        spawnTimer = currentSpawnTime;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        currentSpawnTime = Mathf.Max(currentSpawnTime - spawnTimeReduce, minimumSpawnTime);
        spawnTimer = currentSpawnTime;
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition;
        int maxTry = 50;
        bool isTooClose;
        bool isTooFar;

        do
        {
            float randomX = Random.Range(-spawnRange, spawnRange);
            float randomZ = Random.Range(-spawnRange, spawnRange);
            float positionY = 1.5f;

            randomPosition = transform.position + new Vector3(randomX,positionY,randomZ);

            maxTry--;


            isTooClose = Vector3.Distance(randomPosition, playerTransform.position) < minDistanceToPlayer;
            isTooFar = Vector3.Distance(randomPosition,playerTransform.position) > maxDistanceToPlayer;

        } while ((isTooFar || isTooClose) && maxTry > 0);


        if (maxTry > 0)
        {
            GameObject enemyObject = Instantiate(enemyPrefab,randomPosition,Quaternion.identity);
            enemyObject.GetComponent<EnemyMovement>().SetPlayer(playerTransform);
        }

    }
}
