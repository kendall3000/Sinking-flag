using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PixelWipeTransition : MonoBehaviour
{
    [SerializeField] private Material wipeMaterial;
    [SerializeField] private float wipeSpeed = 1f;
    [SerializeField] private float cutoffDuration = 1f;

    private float cutoffStartTime;
    private bool isWiping = false;

    void Start()
    {
        // Set the initial cutoff value
        wipeMaterial.SetFloat("_Cutoff", 1f);
        
        // Start the wipe transition
        StartCoroutine(WipeRoutine());
    }

    IEnumerator WipeRoutine()
    {
        // Start the cutoff timer
        cutoffStartTime = Time.time;

        while (Time.time - cutoffStartTime < cutoffDuration)
        {
            // Calculate the current cutoff value based on time and speed
            float cutoffValue = Mathf.Lerp(1f, 0f, (Time.time - cutoffStartTime) * wipeSpeed);
            
            // Set the cutoff value in the shader
            wipeMaterial.SetFloat("_Cutoff", cutoffValue);

            yield return null;
        }

        // Ensure the cutoff value is fully transitioned
        wipeMaterial.SetFloat("_Cutoff", 0f);
        
        // Load the next scene
        SceneManager.LoadScene("Midterm1");
    }
}
