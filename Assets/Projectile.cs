using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Destructable"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
