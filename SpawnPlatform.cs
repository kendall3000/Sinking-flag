using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public List <GameObject> platformList = new List <GameObject>();
    public float spawnTime;
    private float spawnCountTime;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }
    public void SpawnPlatforms(){
        spawnCountTime += Time.deltaTime;
        spawnPosition=transform.position;
        spawnPosition.x = Random.Range(-7.0f, 7.0f);

        if (spawnCountTime >= spawnTime){
            platformAppearance();
            spawnCountTime = 0;
        
        }
    }

    public void platformAppearance(){
        int index = Random.Range(0, platformList.Count);
        Instantiate(platformList[index], spawnPosition, Quaternion.identity);
    }
}
