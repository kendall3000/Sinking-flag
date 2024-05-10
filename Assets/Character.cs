/*using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;       // Movement speed of the character
    [SerializeField] private float jumpForce = 10f;      // Force applied when jumping

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));

        // Character movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping with spacebar or up arrow
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Kiko playerName;

    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            input.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            input.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input.x = 1;
        }

        //playerName.MovePlayer(input);
    }
}
