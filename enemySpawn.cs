// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class enemySpawn : MonoBehaviour
// {

//     [SerializeField] public GameObject enemyPrefab; // Assign the enemy prefab in the inspector
//     [SerializeField] public Transform[] spawnPoints; // Assign spawn points in the inspector
//     [SerializeField] private Camera mainCamera;
//     public float spawnDistance = 5f; 
//     public float spawnInterval = 10f; // Time between spawns

//     private void Start()
//     {
//         InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
//     }
    
//     void SpawnEnemy()
//     {
//         if (spawnPoints.Length == 0) return;

//         float spawnX = mainCamera.transform.position.x + (spawnDistance * (Random.value > 0.5f ? 1 : -1));
//         Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);
//         GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
//         //GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
//         activeEnemies.Add(enemy);
//         StartCoroutine(DestroyEnemyAfterTime(enemy, 10));  // Adjust time as needed
//     }
//     IEnumerator DestroyEnemyAfterTime(GameObject enemy, float delay)
//     {
//         yield return new WaitForSeconds(delay);
//         if (enemy != null) {
//             Destroy(enemy);
//             activeEnemies.Remove(enemy);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float spawnDistance = 7f;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private int maxEnemies = 100;
    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }
    
    void SpawnEnemy()
    {
        if (activeEnemies.Count >= maxEnemies) return;

        float spawnX = mainCamera.transform.position.x + (spawnDistance * (Random.value > 0.5f ? 1 : -1));
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        activeEnemies.Add(enemy);
        StartCoroutine(DestroyEnemyAfterTime(enemy, 30)); // Adjust as needed
    }

    IEnumerator DestroyEnemyAfterTime(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (enemy != null) {
            activeEnemies.Remove(enemy);
            Destroy(enemy);
        }
    }
}
