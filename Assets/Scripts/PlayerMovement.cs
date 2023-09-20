using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private float horizontal;
    private float speed = 2f;
    private float jumpingPower = 12f;
    private bool facingRight = true;

    // Serialised Feilds (Visible in Unity Editor without being public)
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        // Get horizontal movement input
        horizontal = Input.GetAxisRaw("Horizontal");

        // Get jump input and jump if currently on the ground
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Start slowing down after jump button released - allows higher jump if button held for longer
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Flip character based on direction curently facing
        Flip();
    }

    // Update called every fixed unity physics frame
    private void FixedUpdate()
    {
        // Update velocity based on horizontal input
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // Flip character based on direction curently facing
    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            if (facingRight == true)
            {
                facingRight = false;
            }
            else if (facingRight == false)
            {
                facingRight = true;
            }
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Function that returns a bool stating if the player is currently on the ground
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
