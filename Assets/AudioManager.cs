using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip pointCollectedSound;
    public AudioClip obstacleHitSound;
    public AudioClip backgroundMusic;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPointCollectedSound()
    {
        audioSource.PlayOneShot(pointCollectedSound);
    }

    public void PlayObstacleHitSound()
    {
        audioSource.PlayOneShot(obstacleHitSound);
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}