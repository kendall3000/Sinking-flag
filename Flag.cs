using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public GameObject endGameUI;  // Assign a UI panel with options to replay or choose another map

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;  // Pause the game
            endGameUI.SetActive(true);  // Show end game options
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;  // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }

    public void ChooseAnotherMap()
    {
        Time.timeScale = 1;  // Resume the game
        SceneManager.LoadScene("MapChoices");  // Load the scene where player can choose another map
    }
}
