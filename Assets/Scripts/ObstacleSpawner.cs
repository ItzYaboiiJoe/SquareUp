using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint; // Reference to the empty GameObject in the scene
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
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);

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
                Debug.Log("Obstacle passed despawn point: " + obstacle.name);
                Destroy(obstacle);
            }
        }
    }
}
