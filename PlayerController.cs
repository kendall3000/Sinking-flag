
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int health;
    public int score;

    public void SavePlayerData()
    {
        GameState gameState = new GameState
        {
            score = this.score,
            playerPosition = transform.position,
            health = this.health
        };

        GameManagerMidterm.SaveGame(gameState);
    }

    public void LoadPlayerData()
    {
        GameState loadedState = GameManagerMidterm.LoadGame();
        transform.position = loadedState.playerPosition;
        score = loadedState.score;
        health = loadedState.health;
    }

    public PlayerController playerController;

    public void OnSaveGamePressed()
    {
        playerController.SavePlayerData();
        Debug.Log("Game Saved!");
    }

    public void OnLoadGamePressed()
    {
        playerController.LoadPlayerData();
        Debug.Log("Game Loaded!");
    }
}
