 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    Vector3 movement;
    public float speed;
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
    void platformMovement(){
        transform.position += movement * Time.deltaTime;
        if(transform.position.y >= boundary.transform.position.y){
            Destroy(gameObject);
        }
    }
}
