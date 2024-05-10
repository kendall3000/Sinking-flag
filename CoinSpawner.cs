using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] public GameObject coinPrefab;
    [SerializeField] public float spawnInterval = 4f;
    [SerializeField] public int coinsPerRow = 5;
    public float minHeight = -3f;
    public float maxHeight = 3f;
    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnCoins", 0, spawnInterval);
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsPerRow; i++)
        {
            float randomX = Random.Range(0.1f, 0.9f); // Randomize x position across the viewport
            Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(randomX, 1, mainCamera.nearClipPlane));
            float yPosition = Mathf.Lerp(minHeight, maxHeight, i / (float)(coinsPerRow - 1));
            Vector3 position = new Vector3(spawnPosition.x, yPosition, 0);
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}

