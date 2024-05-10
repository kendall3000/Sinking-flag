using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<MidtermPlayer>() != null){
            other.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
