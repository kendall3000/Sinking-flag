using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_flag : MonoBehaviour
{
    Vector3 movement;
    public float speed = 2;
    GameObject boundary;

    // Start is called before the first frame update
    void Start()
    {
        movement.y = speed;
        boundary = GameObject.Find("Endpoint");
    }

    // Update is called once per frame
    void Update()
    {
        platformMovement();
    }

    void platformMovement()
    {
        if (transform.position.y < boundary.transform.position.y)
        {
            // Platform moves up until it reaches the boundary
            transform.position += movement * Time.deltaTime;
        }
        else
        {
            // Stop the platform at the boundary
            transform.position = new Vector3(transform.position.x, boundary.transform.position.y, transform.position.z);
            movement = Vector3.zero; // Stop further movement
        }
    }
}
