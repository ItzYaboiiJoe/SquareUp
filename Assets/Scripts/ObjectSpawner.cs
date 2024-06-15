using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        //Calculate time to spawn objects
        if(Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + 1f / spawnRate; 
        }
    }

    //Handles the spawning of objects
    void SpawnObject()
    {
        // Randomly select an object from the array
        int randomIndex = Random.Range(0, objectSpawner.Length);
        GameObject spawnedObject = Instantiate(objectSpawner[randomIndex], spawnPoint.position, Quaternion.identity);

        // Add a Rigidbody2D and Collider2D to the spawned object if not already present
        if (spawnedObject.GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = spawnedObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Set gravity scale to 0 for 2D side-scroller
            rb.isKinematic = true; // Make it kinematic since we are moving it manually
        }
        if (spawnedObject.GetComponent<Collider2D>() == null)
        {
            Collider2D collider = spawnedObject.AddComponent<BoxCollider2D>(); // Assuming a BoxCollider2D
            collider.isTrigger = true; // Set as trigger
        }

        // Add an Obstacle script to handle collision
        if (spawnedObject.GetComponent<ObjectSpawner>() == null)
        {
            spawnedObject.AddComponent<ObjectSpawner>();
        }

        // Start moving the spawned object towards the player
        StartCoroutine(MoveObjectTowardsPlayer(spawnedObject));
    }

    IEnumerator MoveObjectTowardsPlayer(GameObject obj)
    {
        while(obj != null)
        {
            // Move the object towards the player
            Vector2 direction = (player.position - obj.transform.position).normalized;
            obj.transform.position += (Vector3)direction * objectSpeed * Time.deltaTime;

            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerManager>().GameOver();

        }
    }

}
