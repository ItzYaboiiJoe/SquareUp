using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour

{
    public float speed = 1.0f;
    public Vector3 targetPostion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the speed of obstacle

        //Move obstacle towards the target postion
        transform.position = Vector3.MoveTowards(transform.position, targetPostion, speed);
    }
}
