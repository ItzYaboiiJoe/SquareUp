using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffectMultiplier;
    private float length;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * parallaxEffectMultiplier, length);
        transform.position = startPos + Vector3.left * newPosition;
    }
}

