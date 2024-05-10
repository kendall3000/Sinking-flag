using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MidtermPlayer : MonoBehaviour
{
    [Header("Basic Starter Stats")]
    //[SerializeField] int lives = 3;
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void MovePlayer(Vector3 direction)
    {
        // Calculate velocity based on direction and speed
        Vector2 movement = new Vector2(direction.x, direction.y).normalized;
        rb.velocity = movement * speed;

        // Prevent player from leaving the screen
        Vector2 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -12f, 12f); // Assuming the screen width is from -8 to 8
        newPos.y = Mathf.Clamp(newPos.y, -6.5f, 6.5f); // Assuming the screen height is from -4 to 4
        transform.position = newPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="PointProjectile")
        {
            // Increment score
            ScoreManager.Instance.IncreaseScore();

            // Play sound
            AudioManager.Instance.PlayPointCollectedSound();

            // Destroy the point projectile
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "ObstacleProjectile")
        {
            // Restart the game or send player back to main menu
            GameManager.Instance.RestartGame(); // Implement GameManager for game management
        }
    }
    public void PickupCoin()
    {
        CoinCounter.singleton.RegisterCoin();
        //GetComponent<AudioSource>().Play();
    }

}

