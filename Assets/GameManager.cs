using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void RestartGame()
    {
        Debug.Log("Restarting the game.");
        // Reload the current scene (restart game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
