using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    public float jumpForce = 10f; // Force applied for jumping
    public LayerMask groundLayer; // Layer for ground detection

    private Rigidbody2D rb; // Rigidbody2D component reference
    private Animator animator; // Animator component reference
    private bool isGrounded; // Boolean to check if the character is on the ground

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Freeze rotation on Z-axis to prevent rolling
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");
        // Update velocity for horizontal movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Prevent sticking to walls
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            if (Physics2D.Raycast(transform.position, Vector2.right * moveInput, 0.1f, groundLayer))
            {
                // Apply a small force to push away from the wall
                rb.velocity = new Vector2(-moveInput * 0.5f, rb.velocity.y); // Adjust the 0.5f value as needed
            }

            // Flip sprite based on movement direction
            transform.localScale = new Vector3(moveInput > 0 ? 1 : -1, 1, 1);
        }
    }

    private void Jump()
    {
        // Check if the character is grounded using a raycast
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        // Only allow jumping if the character is grounded
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply upward force for jump
        }
    }
}
