using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;

    // Method to restart the game by loading a specific map
    public void GameRestart(string mapName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mapName); // Load the specified map
    }

    // Example methods to load each specific map
    public void RestartUnderwater()
    {
        Time.timeScale = 1;
        GameRestart("MapUnderwater1");
    }

    public void RestartForest()
    {
        Time.timeScale = 1;
        GameRestart("MapForest1");
    }

    public void RestartVolcano()
    {
        Time.timeScale = 1;
        GameRestart("MapVolcano1");
    }

    public void RestartLaboratory()
    {
        Time.timeScale = 1;
        GameRestart("MapLaboratory1");
    }
}
