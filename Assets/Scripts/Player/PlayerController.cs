using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //this allow variable to be adjusted in settings
    [SerializeField] public float jumpForce = 50f;
    // [SerializeField] public float crouchScale = 0.5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    // private bool isCrouching;

  
    public static MenuController Instance { get; private set; }

    private Vector3 originalScale;

    //get score manager info 
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        //find score manager scene
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && (Input.GetButtonDown("Jump") || IsJumpTouch()))
        {
            Jump(); //This calls the method jump
        }

        /*
        // Check for crouch input
        if (Input.GetButtonDown("Crouch") || IsCrouchTouch())
        {
            Crouch();
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            StandUp();
        }
        */
    }
    private bool IsJumpTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    return true;
                }
            }
        }
        return false;
    }
    //THIS IS THE TOUCH FEATURE FOR CROUCHING
    /* 
    private bool IsCrouchTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Check if the touch position is in the lower half of the screen
                if (touch.position.y < Screen.height / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
    */

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //This calls soundJump from class SoundEffectsManager
        SoundEffectsManager.instance.PlaySound(SoundEffectsManager.instance.jumpSound);
        isGrounded = false;
    }

    // private void Crouch()
    // {
    //     isCrouching = true;
    //     // Reduce the player's scale when crouching
    //     transform.localScale = new Vector3(originalScale.x, originalScale.y * crouchScale, originalScale.z);
    // }

    // private void StandUp()
    // {
    //     isCrouching = false;
    //     // Restore the player's original scale when standing up
    //     transform.localScale = originalScale;
    // }

    //check if player o nground based on layer asset

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with an object tagged as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // If the player hits an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Ensure the player stays grounded when colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Ensure the player is no longer grounded when leaving the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            //increase score when collecitng coin
            scoreManager.scoreCount += 100; //WE CAN CHANGE THIS LATER
            Destroy(other.gameObject);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game OVER sucka");
        MenuController.GameOverLoad();
    }
}