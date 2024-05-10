using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedSpawnPoint : MonoBehaviour
{
    public float minX = -8f; // Left boundary
    public float maxX = 8f;  // Right boundary
    public float topY = 4f;  // Top boundary

    void Start()
    {
        // Randomize the X-position within the specified range
        float randomX = Random.Range(minX, maxX);

        // Set the position of the GameObject
        transform.position = new Vector3(randomX, topY, 0f);
    }
}

