using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //this allow variable to be adjusted in settings
    [SerializeField] public float jumpForce = 50f;
    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump(); //This calls the method jump
        }
    }

    private void Jump()
    {
        //Allows player to jump from the serialized Component
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        //This calls soundJump from class SoundEffectsManager
        SoundEffectsManager.instance.PlaySound(SoundEffectsManager.instance.jumpSound);

        isGrounded = false;
    }
    //check if player o nground based on layer asset
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}