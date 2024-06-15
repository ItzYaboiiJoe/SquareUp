using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Create array of objects to spawn (we can add assets for for obstacles)
    public GameObject[] objectSpawner;
    //spawn intervals (Delay timer)
    [SerializeField] public float spawnInterval = 2f;
    //spawn y position
    [SerializeField] public float spawnPosY = 0f;
     // WE can make this a static number in the future (this will allow objects to spawn faster as game progresses)
    [SerializeField] public float objectSpeed;

    void Start()
    {
        //Start the spawing object at "spawnIntervals"
    }

    //Handles the spawning of objects
    void SpawnObject()
    {
        //Select objects from array and play in POS 

        //create a boxcollider or rigidbody to give obstacles a official node
    }
}
