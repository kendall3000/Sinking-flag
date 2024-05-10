using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Color fadeColor = Color.black; // Color used for fading
    public float transitionTime = 1f;

    private float transitionTimer = 0f;
    private bool isTransitioning = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        isTransitioning = true;

        // Fade in
        while (transitionTimer < transitionTime)
        {
            transitionTimer += Time.deltaTime;
            yield return null;
        }

        // Load next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No next scene available.");
        }

        // Reset timer and fade out
        transitionTimer = 0f;
        isTransitioning = false;
    }

    void OnGUI()
    {
        if (isTransitioning)
        {
            // Calculate alpha value based on transition progress
            float alpha = Mathf.Clamp01(transitionTimer / transitionTime);

            // Set color and draw texture to cover screen
            GUI.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }
}
