using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        //Debug.Log("Pausing game");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

    public void SaveGame()
    {
        GameState gameState = new GameState();
        // Populate gameState with relevant data (e.g., score, player position, health)
        GameManagerMidterm.SaveGame(gameState);
        //Debug.Log("data has been saved");
    }

    public void LoadGame()
    {
        GameState gameState = GameManagerMidterm.LoadGame();
        // Use gameState data to resume the game (e.g., set player position, update score and health)
        // Example: transform.position = gameState.playerPosition;
    }
}
