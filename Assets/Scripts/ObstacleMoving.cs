using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoving : MonoBehaviour

{
    public float speed = 1.0f;
    public Vector3 targetPosition;

    void Update()
    {
        //Move obstacle towards the target postion
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
}
