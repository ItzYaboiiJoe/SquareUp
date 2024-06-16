using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Create array of objects to spawn (we can add assets for for obstacles)
    public GameObject[] objectSpawner;
    public Transform spawnPoint;
    public Transform player;
    [SerializeField] public float spawnRate;
    [SerializeField] public float objectSpeed;
    public float nextSpawnTime = 0f;

    //FROM OLD SCRIPT
    [SerializeField] private Transform playerTransform; // Reference to the player's transform
    [SerializeField] private float despawnMargin = 10f; // Margin to despawn behind the player

    private void Update()
    {
        //Calculate time to spawn objects
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    //Handles the spawning of objects
    void SpawnObject()
    {
        // Select a random obstacle prefab from the array
        GameObject obstacleToSpawn = objectSpawner[Random.Range(0, objectSpawner.Length)];

        // Instantiate the obstacle at the spawn point
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned obstacle at position: " + spawnPoint.position);

        // Move the obstacle towards the target position
        StartCoroutine(MoveObstacle(spawnedObstacle, player.position, objectSpeed));
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
