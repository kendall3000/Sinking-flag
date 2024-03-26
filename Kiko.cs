using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


using UnityEngine;

/*public class Kiko : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;       // Movement speed of the character
    [SerializeField] public float jumpForce = 10f;      // Force applied when jumping
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump = true; // Flag to control whether the player can jump

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Character movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping (only allowed when grounded and canJump is true)
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false; // Set canJump to false to prevent double jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with a platform, then allow jumping
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }

    private bool IsGrounded()
    {
        // Cast a ray downward from the player's position to check for collisions with platforms
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Check if the ray hits a platform
        return hit.collider != null && hit.collider.CompareTag("Platform");
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiko : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;       // Movement speed of the character
    [SerializeField] private float jumpForce = 10f;      // Force applied when jumping
    private Rigidbody2D rb;
    private bool canJump = true; // Flag to control whether the player can jump

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Character movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping (only allowed when canJump is true)
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false; // Set canJump to false to prevent double jumping
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Allow jumping if the player collides with a platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset canJump when the player leaves the platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = false;
        }
    }
}
