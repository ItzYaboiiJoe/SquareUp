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
            float spawnInterval = Random.Range(minSpawnInterval,maxSpawnInterval);

            //Randomly choose with thing to spawn
            GameObject objToSpawn = Random.value > 0.5f ? obstaclePrefab : coinPrefab;

            GameObject obstacle = Instantiate(objToSpawn, spawnPoint.position, Quaternion.identity);

            Vector2 direction = (Vector2.zero - (Vector2)obstacle.transform.position).normalized;
            obstacle.GetComponent<Rigidbody2D>().velocity = direction * obstacleSpeed;

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
                Destroy(obstacle);
            }
        }
                foreach (var obstacle in GameObject.FindGameObjectsWithTag("Coin"))
        {
            if (obstacle.transform.position.x < despawnPoint.position.x)
            {
                Destroy(obstacle);
            }
        }
    }
}
