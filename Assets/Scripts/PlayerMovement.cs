using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private float horizontal;
    private bool facingRight = true;
    public float coyoteTimeTimer;
    public float jumpCooldown = 0f;
    private float jumpInputBuffer = 0f;

    // Serialised Feilds (Visible in Unity Editor without being public)
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpingPower = 12f;

    public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // Get horizontal movement input
        horizontal = Input.GetAxisRaw("Horizontal");

        // Tell the animator if the player is moving
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Get jump input and jump if currently on the ground
        if (Input.GetButtonDown("Jump") && coyoteTimeTimer > 0f)
        {
            coyoteTimeTimer = 0f;
            jumpCooldown = 5f;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Input buffering, allows the player to press jump a few frames before landing and still be able to jump
        if (Input.GetButtonDown("Jump") && coyoteTimeTimer == 0f)
        {
            jumpInputBuffer = 10f;
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

        // Coyote Time implementation
        if (IsGrounded() && jumpCooldown == 0)
        {
            coyoteTimeTimer = 10f;
        }
        else
        {
            if (coyoteTimeTimer >= 1f)
            {
                coyoteTimeTimer += -1f;
            }
        }
        // Jump cooldown removes double jump that was occuring because of framerate difference between update/fixedupdate
        if (jumpCooldown > 0f)
        {
            jumpCooldown += -1f;
        }

        // Input buffer for jumping
        if (jumpInputBuffer > 0)
        {
            jumpInputBuffer += -1f;

            if (IsGrounded() && jumpCooldown == 0)
            {
                coyoteTimeTimer = 0f;
                jumpCooldown = 5f;
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                jumpInputBuffer = 0;
            }
        }
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
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
