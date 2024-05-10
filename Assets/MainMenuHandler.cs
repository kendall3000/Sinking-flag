// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenuHandler : MonoBehaviour
// {
//     [SerializeField] private ScreenFader screenFader;
//     public void PlayGame()
//     {
//         SceneManager.LoadScene("MapChoices"); // Change "GameScene" to your actual game scene name
//         // include the 4 different maps 
//         // forest 
//         // sinking boat
//         // volcano 
//         // technology laboratory provide those different scene options
//     }

//     public void OpenOptions()
//     {
//         // You can load an options scene or simply toggle an options menu visibility here
//         Debug.Log("Open options menu here");
//     }

//     public void QuitGame()
//     {
//         Debug.Log("Quit game");
//         Application.Quit(); // Note: This will not do anything in the editor, but will work in a built game
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;
    public void startGame()
    {
        // This can load a scene that allows the player to select a map
        SceneManager.LoadScene("MainMenu"); 
    }

    public void PlayGame()
    {
        // This can load a scene that allows the player to select a map
        SceneManager.LoadScene("Restart"); 
    }

    public void OpenOptions()
    {
        // Load the Options scene
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
