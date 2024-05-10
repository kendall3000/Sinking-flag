using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 5f;

    private Vector3 spawnPosition;
    private float leftLimit;
    private float rightLimit;
    private bool movingLeft = true;

    private void Start()
    {
        spawnPosition = transform.position;
        leftLimit = spawnPosition.x - patrolDistance;
        rightLimit = spawnPosition.x + patrolDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                GetComponent<SpriteRenderer>().flipX = true;  // Flip sprite to face left
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                GetComponent<SpriteRenderer>().flipX = false;  // Flip sprite to face right
            }
            else
            {
                movingLeft = true;
            }
        }
    }
    public void Initialize(float speed)
    {
        moveSpeed = speed;  // Example of setting the speed
    }
    
}
