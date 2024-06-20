using System;
using System.Numerics;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffectMultiplier;
    private float length;
    private UnityEngine.Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * parallaxEffectMultiplier, length);
        transform.position = startPos + UnityEngine.Vector3.left * newPosition;
    }
}