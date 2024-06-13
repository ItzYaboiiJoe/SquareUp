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
    [SerializeField] private float crouchHeightFactor = 0.5f;

    private bool isGrounded = false;
    public bool isJumping = false;
    private float jumpTimer;
    

    private Vector3 originalScale;

    // Add a public boolean to control the jump sound
    public bool jumpSoundEnabled = true;


     // Singleton instance
    public static Movement Instance { get; private set; }

    private void Start()
    {
        originalScale = sprite.localScale;

        // Check if SoundManager instance is available
        if (SoundManager.Instance == null)
        {
            Debug.LogError("SoundManager instance not found in Movement script.");
        }

        // Sync jump sound enabled state with SoundManager
        jumpSoundEnabled = !SoundManager.Instance.effectsSource.mute;
    }

    void Awake()
    {
        //Make sure objects stays away in all scenes
        DontDestroyOnLoad(this.gameObject);

        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(pos.position, groundDist, groundLayer);

        #region JUMPING
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimer = 0;
            if(jumpSoundEnabled && SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayJumpSound();
            }
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        #endregion

        #region CROUCHING
        if (isGrounded && Input.GetButton("Crouch"))
        {
            sprite.localScale = new Vector3(originalScale.x, originalScale.y * crouchHeightFactor, originalScale.z);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            sprite.localScale = originalScale;
        }
        #endregion
    }

    // Method to toggle the jump sound
    public void ToggleJumpSound()
    {
        jumpSoundEnabled = !jumpSoundEnabled;

        // Sync the jump sound state with SoundManager
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.ToggleEffects(jumpSoundEnabled);
        }
    }
}
