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
    private Rigidbody2D rb;
    private bool isGrounded;
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

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //This calls soundJump from class SoundEffectsManager
        SoundEffectsManager.instance.PlaySound(SoundEffectsManager.instance.jumpSound);
        isGrounded = false;
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            //increase score when collecitng coin
            scoreManager.scoreCount += 100; //WE CAN CHANGE THIS LATER
            Debug.Log("This just added score and it has been collider");
            Destroy(other.gameObject);
        }
    }

    private void GameOver()
    {
        Debug.Log("Game OVER sucka");
        MenuController.GameOverLoad();
    }
}