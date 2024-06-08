using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded;
    private Transform groundCheck;
    private LayerMask groundLayer;

    private void Update()
    {
        isGrounded = false;
    }
}
