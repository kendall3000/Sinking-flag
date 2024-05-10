using UnityEngine;
using System.Collections;
public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject[] itemPrefabs;  // Assign your 4 different item prefabs here
    public float spawnInterval = 10f;

    // Probabilities for each item
    private float[] spawnProbabilities = { 0.15f, 0.3f, 0.5f, 0.05f}; // Example probabilities for 4 items

    private void Start()
    {
        InvokeRepeating("SpawnItem", 2f, spawnInterval);
    }

    void SpawnItem()
    {
        float randomPoint = Random.value;
        float currentProb = 0f;

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            currentProb += spawnProbabilities[i];
            if (randomPoint <= currentProb)
            {
                float spawnX = mainCamera.transform.position.x + Random.Range(-5f, 5f); // Adjust range as needed
                float spawnY = mainCamera.transform.position.y + Random.Range(-3f, 3f); // Adjust range as needed
                Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
                Instantiate(itemPrefabs[i], spawnPosition, Quaternion.identity);
                break;
            }
        }
    }
    
}
