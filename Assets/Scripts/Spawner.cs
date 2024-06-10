using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obsPrefabs;
    public float obsSpawnTime = 2f;
    public float obsSpeed = 5f;

    private float timeUntilObsSpawn;

    private void Update()
    {
        SpawnLoop();
         
    }

    private void SpawnLoop(){
        timeUntilObsSpawn += Time.deltaTime;

        
        if(timeUntilObsSpawn >= obsSpawnTime){
            Spawn();
            timeUntilObsSpawn = 0f;
        }
    }

    private void Spawn(){
        GameObject obstacleToSpawn = obsPrefabs[Random.Range(0, obsPrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Debug.Log("Obs position is" + transform.position);
        Rigidbody2D obstacleRB  = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obsSpeed;
    }
}
