using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab; // Platform prefab to spawn
    [SerializeField] private int maxPlatforms = 10; // Maximum number of platforms allowed
    [SerializeField] private float spawnInterval = 2f; // Time interval between platform spawns
    [SerializeField] private float platformSpeed = 2f; // Speed at which platforms move downward
    public float recycleThreshold = -10f; // Y position at which platforms are recycled
    [SerializeField] private float gravityScale = 1f; // Gravity scale for platforms

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        // Check if it's time to spawn a new platform and if the maximum limit is not reached
        if (Time.time >= nextSpawnTime && GameObject.FindGameObjectsWithTag("Platform").Length < maxPlatforms)
        {
            SpawnPlatform();
            nextSpawnTime = Time.time + spawnInterval; // Update next spawn time
        }

        // Move and recycle platforms
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            Rigidbody2D platformRb = platform.GetComponent<Rigidbody2D>();
            if (platformRb != null)
            {
                platformRb.gravityScale = gravityScale; // Set the gravity scale for the platform
            }

            platform.transform.Translate(Vector3.down * platformSpeed * Time.deltaTime);

            // Check if the platform is below the recycle threshold
            if (platform.transform.position.y < recycleThreshold)
            {
                RecyclePlatform(platform);
            }
        }
    }

    void SpawnPlatform()
    {
        // Get the spawn position
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 10f, 0f); // Example spawn position (random x, fixed y)

        // Instantiate the platform prefab at the spawn position
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        // Tag the platform GameObject for movement
        platform.tag = "Platform";
    }

    void RecyclePlatform(GameObject platform)
    {
        // Reset the platform's position to the top of the screen
        platform.transform.position = new Vector3(Random.Range(-5f, 5f), 10f, 0f); // Example spawn position (random x, fixed y)
    }
}
