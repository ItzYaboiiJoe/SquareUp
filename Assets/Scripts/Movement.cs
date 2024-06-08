using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDist = 0.25f;
    [SerializeField] private float jumptime = 0.5f;
    [SerializeField] private Transform pos;

    private bool isGrounded = false;
    private bool isJumping = false;
   // private LayerMask groundLayer;

    private void Update()
    {
       isGrounded = Physics2D.OverlapCircle(pos.position, groundDist, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump")){
            isJumping = true;
           rb.velocity = Vector2.up * jumpForce;
          System.Console.WriteLine("THIS COMMAND DOES JUMPY SHGIT");
        }
        if (isJumping && Input.GetButton("Jump")){
            rb.velocity = Vector2.up * jumpForce
;        }
        
    }
}
