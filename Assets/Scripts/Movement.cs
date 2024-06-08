using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform sprite;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDist = 0.25f;
    [SerializeField] private Transform pos;
    [SerializeField] private float jumpTime = 0.2f;

    private bool isGrounded = false;
    public bool isjumping = false;
    private float jumpTimer;


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(pos.position, groundDist, groundLayer);



        #region JUMPING

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isjumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }


            isjumping = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isjumping = false;
        }
        #endregion
    }


}
