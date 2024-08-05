using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab; 
    public Transform spawnPoint; // Reference to the empty GameObject in the scene
    public float minSpawnInterval = 3f;
    public float maxSpawnInterval = 6f;
    public float spawnInterval = 6f; // Start with 6
    public float obstacleSpeed = 50f; // Start with 50
    public Transform despawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
    while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Randomly choose which object to spawn
            GameObject objToSpawn = Random.value > 0.5f ? obstaclePrefab : coinPrefab;
            GameObject spawnedObject = Instantiate(objToSpawn, spawnPoint.position, Quaternion.identity);

            Vector2 direction = (Vector2.zero - (Vector2)spawnedObject.transform.position).normalized;
            spawnedObject.GetComponent<Rigidbody2D>().velocity = direction * obstacleSpeed;

            Debug.Log($"Spawned {spawnedObject.tag} at {spawnPoint.position} with interval {spawnInterval}s");

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        // Check if any obstacles have passed the despawn point and destroy them
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            if (obstacle.transform.position.x < despawnPoint.position.x)
            {
                Debug.Log($"Destroying obstacle at {obstacle.transform.position}");
                Destroy(obstacle);
            }
        }
             // Check if any coins have passed the despawn point and destroy them
        foreach (var coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            if (coin.transform.position.x < despawnPoint.position.x)
            {
                Debug.Log($"Destroying coin at {coin.transform.position}");
                Destroy(coin);
            }
        }
    }
}
