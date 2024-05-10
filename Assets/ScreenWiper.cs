using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenWiper : MonoBehaviour
{
    [SerializeField] private Image wipeImage;
    [SerializeField] private Color wipeColor = Color.black;
    [SerializeField] private float wipeTime = 1;

    void Start()
    {
        // Start the wipe transition
        WipeTransition();
    }

    void WipeTransition()
    {
        // Set the initial color of the wipe image to wipeColor with alpha 0
        wipeImage.color = new Color(wipeColor.r, wipeColor.g, wipeColor.b, 0);
        StartCoroutine(WipeRoutine());
    }

    IEnumerator WipeRoutine()
    {
        float timer = 0;

        // Loop until the timer reaches the wipeTime
        while (timer < wipeTime)
        {
            yield return null;
            timer += Time.deltaTime;

            // Interpolate the alpha value of the wipe image from 0 to 1 over time
            float alpha = Mathf.Clamp01(timer / wipeTime);
            wipeImage.color = new Color(wipeColor.r, wipeColor.g, wipeColor.b, alpha);
        }

        // Ensure the wipe color is fully visible
        wipeImage.color = wipeColor;

        // Load the next scene
        SceneManager.LoadScene("Midterm1");
    }
}
