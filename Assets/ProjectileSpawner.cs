using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject pointProjectilePrefab;
    [SerializeField] GameObject obstacleProjectilePrefab;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float minX = -16f; // Left boundary
    [SerializeField] float maxX = 16f;  // Right boundary
    [SerializeField] float minY = -10f; // Bottom boundary
    [SerializeField] float maxY = 10f;  // Top boundary

    void Start()
    {
        InvokeRepeating("SpawnProjectiles", 0f, spawnInterval);
    }

    void SpawnProjectiles()
    {
        // Spawn point projectile
        Vector3 pointSpawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        GameObject pointProjectile = Instantiate(pointProjectilePrefab, pointSpawnPosition, Quaternion.identity);
        Rigidbody2D pointRb = pointProjectile.GetComponent<Rigidbody2D>();
        pointRb.velocity = Vector2.down * Random.Range(3f, 6f); // Adjust direction

        // Spawn obstacle projectile
        Vector3 obstacleSpawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        GameObject obstacleProjectile = Instantiate(obstacleProjectilePrefab, obstacleSpawnPosition, Quaternion.identity);
        Rigidbody2D obstacleRb = obstacleProjectile.GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.down * Random.Range(3f, 6f); // Adjust direction
    }
}



