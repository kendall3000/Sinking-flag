using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kiko : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 5f; // Health variable
    [SerializeField] public GameObject gameOverPanel;
    [SerializeField] private List<AnimationStateChanger> animationStateChangers;
    private float minYValue = -9.5f; 
    
    

    private Rigidbody2D rb;
    private bool isJumping;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Prevent moving left if at the left boundary
        if (transform.position.x <= -8.9 && moveInput < 0)
        {
            moveInput = 0;
        }

        // Set the horizontal velocity
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite if necessary
        if ((moveInput > 0 && transform.localScale.x < 0) || (moveInput < 0 && transform.localScale.x > 0))
        {
            Flip();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            isGrounded = false;
            UpdateAnimationState("Jump");
        }

        // Update animation based on movement
        if (Mathf.Abs(rb.velocity.x) < 0.01f && isGrounded && !isJumping)
        {
            UpdateAnimationState("Idle");
        }
        else if (Mathf.Abs(rb.velocity.x) > 0.01f && isGrounded)
        {
            UpdateAnimationState("Walk");
        }


        // Using items
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHealthPotion();  // Method to use health potion
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            UseJumpBoost();  // Method to use jump boost
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            UseSpeedBoost();  // Method to use speed boost
        }
        if (SceneManager.GetActiveScene().name == "MapUnderwater1" && transform.position.y < minYValue)
        {
            GameOver();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
            isJumping = false;
            UpdateAnimationState("Walk");
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (IsPlayerAboveEnemy(collision))
            {
                Destroy(collision.gameObject); // Enemy dies if jumped on
            }
            else
            {
                TakeDamage(1);
            }
        }
        // else if (collision.gameObject.CompareTag("DamageTile"))
        // {
        //     TakeDamage(.25f); // Change the damage value as per your game design
        // }
    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    private void UpdateAnimationState(string newState)
    {
        foreach (var changer in animationStateChangers)
        {
            changer.ChangeAnimationState(newState);
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            Debug.Log("Player died");
            GameOver();
        }
    }

    bool IsPlayerAboveEnemy(Collision2D collision)
    {
        float enemyTop = collision.collider.bounds.center.y + collision.collider.bounds.extents.y;
        return transform.position.y > enemyTop;
    }
    public void UseHealthPotion()
    {
        if (GetComponent<InventoryManager>().UseItem("HealthPotion"))
        {
            health = Mathf.Min(health + 1, maxHealth); // Assuming you define maxHealth
            Debug.Log("Health Restored. Current Health: " + health);
        }
    }

    public void UseJumpBoost()
    {
        if (GetComponent<InventoryManager>().UseItem("JumpBoost"))
        {
            StartCoroutine(ApplyJumpBoost());
        }
    }

    IEnumerator ApplyJumpBoost()
    {
        float originalJumpForce = jumpForce;
        jumpForce *= 2;
        yield return new WaitForSeconds(15); // Boost lasts for 15 seconds
        jumpForce = originalJumpForce;
    }
    private IEnumerator SpeedBoost(float duration, float multiplier)
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
    }

    public void UseSpeedBoost()
    {
        StartCoroutine(SpeedBoost(15f, 2f));  // Boost lasts for 15 seconds, speed is doubled
    }
    public void GameOver()
    {
        Debug.Log("Player died. Game over!");
        // Display game over/restart UI
        gameOverPanel.SetActive(true);  // Make sure to assign this in the inspector
        Time.timeScale = 0;  // Pause the game
        
    }


}
