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
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private float crouchHeight = 0.5f;

    private bool isGrounded = false;
    private bool isjumping = false;
    private float jumpTimer;



    //This code is now broken to when is key is tapped it cannot be pressed again. Attempting to debug the code here. 

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(pos.position, groundDist, groundLayer);



        #region JUMPING


        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isjumping = true;
          //  jumpTimer = 0f; //This is suppose to reset the jumptimer so player can jump again
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
        }


        if (Input.GetButtonUp("Jump"))
        {
            isjumping = false;
        }
        

        #endregion


    //THIS FEATURE IS BREAKING THE CONTROL SETUP. I need to debug and fix.
        if (isGrounded && Input.GetButton("Crouch"))
        {
            sprite.localScale = new Vector3(sprite.localScale.x, crouchHeight, sprite.localScale.z);


            if (isjumping){
                sprite.localScale = new Vector3(sprite.localScale.x, 1f, sprite.localScale.z);
            }
           

        }
        if (Input.GetButtonUp("Crouch"))
        {
            sprite.localScale = new Vector3(sprite.localScale.x, 1f, sprite.localScale.z);
        }
        
    }

}
