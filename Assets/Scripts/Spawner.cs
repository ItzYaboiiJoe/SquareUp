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

    private float timeUntilObsSpawn;

    private void Start()
    {
        timeUntilObsSpawn = 0f;
    }

    private void Update()
    {
        timeUntilObsSpawn += Time.deltaTime;

        if (timeUntilObsSpawn >= obsSpawnTime)
        {
            Spawn(); // Call the spawn method
            timeUntilObsSpawn = 0f; // Reset the timer
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obsPrefabs[Random.Range(0, obsPrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);
        Debug.Log("Obs position is" + spawnPoint.position);

        ObstacleMoving obstacleMoving = spawnedObstacle.GetComponent<ObstacleMoving>();
        if (obstacleMoving != null)
        {
            obstacleMoving.SetTargetPosition(targetPosition);
            obstacleMoving.speed = obsSpeed; // Set the speed if needed
        }

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obsSpeed;
    }
}
