using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obsPrefabs; // Array of obstacle prefabs
    [SerializeField] private Transform spawnPoint; // Reference to the spawn point object
    [SerializeField] private float obsSpawnTime = 2f; // Time interval between spawns
    [SerializeField] private float obsSpeed = 5f; // Speed of spawned obstacles
    public Vector3 targetPosition;
    [SerializeField] private Transform playerTransform; // Reference to the player's transform
    [SerializeField] private float despawnMargin = 10f; // Margin to despawn behind the player

    private float timeUntilObsSpawn;

    private void Start()
    {
        timeUntilObsSpawn = obsSpawnTime; // Initialize to spawn an obstacle at the set interval
    }

    private void Update()
    {
        if(GameManger.Instance.isPlaying){
        timeUntilObsSpawn -= Time.deltaTime;

        if (timeUntilObsSpawn <= 0f)
        {
            Spawn(); // Call the spawn method
            timeUntilObsSpawn = obsSpawnTime; // Reset the timer
        }
        }

    }

    private void Spawn()
    {
        // Select a random obstacle prefab from the array
        GameObject obstacleToSpawn = obsPrefabs[Random.Range(0, obsPrefabs.Length)];
        
        // Instantiate the obstacle at the spawn point
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned obstacle at position: " + spawnPoint.position);

        // Move the obstacle towards the target position
        StartCoroutine(MoveObstacle(spawnedObstacle, targetPosition, obsSpeed));
    }

    private IEnumerator MoveObstacle(GameObject obstacle, Vector3 targetPos, float speed)
    {
        while (true)
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, targetPos, speed * Time.deltaTime);
            
            // Check if the obstacle has passed the player's position plus the despawn margin
            if (obstacle.transform.position.x < playerTransform.position.x - despawnMargin)
            {
                Destroy(obstacle);
                yield break;
            }
            
            yield return null;
        }
    }
}
