using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Creature>() != null){
            other.GetComponent<Creature>().PickupCoin();
            Destroy(this.gameObject);
        }
    }
    

}
