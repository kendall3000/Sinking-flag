
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pointProjectilePrefab;
    [SerializeField] GameObject obstacleProjectilePrefab;
    [SerializeField] float obstacleSpeed = 4f;
    [SerializeField] float minSpawnInterval = 0.05f; // Minimum spawn interval
    [SerializeField] float maxSpawnInterval = 1.893f; // Maximum spawn interval
    [SerializeField] int minNumberOfObstacles = 3; // Minimum number of obstacles to spawn
    [SerializeField] int maxNumberOfObstacles = 5; // Maximum number of obstacles to spawn
    [SerializeField] int minNumberOfPointProjectiles = 1; // Minimum number of point projectiles to spawn
    [SerializeField] int maxNumberOfPointProjectiles = 3; // Maximum number of point projectiles to spawn
    [SerializeField] float minX = -12f; // Left boundary
    [SerializeField] float maxX = 12f;  // Right boundary
    [SerializeField] float topY = 7f;  // Top boundary
    private float nextSpawnTime;

    void Start()
    {
        // Set initial spawn time
        SetNextSpawnTime();
    }

   void Update()
{
    // Check if it's time to spawn new obstacles and projectiles
    if (Time.time >= nextSpawnTime)
    {
        // Randomize the number of obstacles and point projectiles to spawn
        int numberOfObstacles = Random.Range(minNumberOfObstacles, maxNumberOfObstacles + 1);
        int numberOfPointProjectiles = Random.Range(minNumberOfPointProjectiles, maxNumberOfPointProjectiles + 1);

        // Spawn the specified number of obstacles
        for (int i = 0; i < numberOfObstacles; i++)
        {
            SpawnObstacle();
        }

        // Spawn the specified number of point projectiles
        for (int i = 0; i < numberOfPointProjectiles; i++)
        {
            SpawnPointProjectile();
        }

        // Spawn obstacle projectiles
        SpawnObstacleProjectile();

        // Update the next spawn time with a random interval
        SetNextSpawnTime();
    }
}


    void SetNextSpawnTime()
    {
        // Set the next spawn time with a random interval
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void SpawnObstacle()
    {
        // Randomize the X-position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Set the spawn position for the obstacle
        Vector3 spawnPosition = new Vector3(randomX, topY, 0f);

        // Instantiate a new obstacle at the specified spawn position
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Set the obstacle's velocity to move downward
        Rigidbody2D rb = newObstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * obstacleSpeed;
        }
    }

    void SpawnPointProjectile()
    {
        // Randomize the X-position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Set the spawn position for the point projectile
        Vector3 spawnPosition = new Vector3(randomX, topY, 0f);

        // Instantiate a new point projectile at the specified spawn position
        GameObject pointProjectile = Instantiate(pointProjectilePrefab, spawnPosition, Quaternion.identity);

        // Set the point projectile's velocity to move downward
        Rigidbody2D pointRb = pointProjectile.GetComponent<Rigidbody2D>();
        if (pointRb != null)
        {
            pointRb.velocity = Vector2.down * Random.Range(3f, 6f); // Adjust direction
        }
    }

    void SpawnObstacleProjectile()
    {
        // Randomize the X-position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Set the spawn position for the obstacle projectile
        Vector3 spawnPosition = new Vector3(randomX, topY, 0f);

        // Instantiate a new obstacle projectile at the specified spawn position
        GameObject obstacleProjectile = Instantiate(obstacleProjectilePrefab, spawnPosition, Quaternion.identity);

        // Set the obstacle projectile's velocity to move downward
        Rigidbody2D obstacleRb = obstacleProjectile.GetComponent<Rigidbody2D>();
        if (obstacleRb != null)
        {
            obstacleRb.velocity = Vector2.down * Random.Range(3f, 6f); // Adjust direction
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="PointProjectile")
        {
            ScoreManager scoreManager = other.GetComponent<ScoreManager>();
            AudioManager audioManager = other.GetComponent<AudioManager>();

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore();
            }

            if (audioManager != null)
            {
                audioManager.PlayPointCollectedSound();
            }

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "ObstacleProjectile")
        {
            GameManager gameManager = other.GetComponent<GameManager>();

            if (gameManager != null)
            {
                Destroy(this.gameObject);
                gameManager.RestartGame();
            }
        }
    }
 
    
}

