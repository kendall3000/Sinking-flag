using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    void PerformPickup(MidtermPlayer player){
        player.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
