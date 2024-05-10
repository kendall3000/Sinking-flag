
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class GameManagerMidterm
{
    public static void SaveGame(GameState gameState)
    {
        string json = JsonUtility.ToJson(gameState);
        PlayerPrefs.SetString("GameState", json);
        PlayerPrefs.Save();
    }

    public static GameState LoadGame()
    {
        string json = PlayerPrefs.GetString("GameState", "{}");
        return JsonUtility.FromJson<GameState>(json);
    }
}

