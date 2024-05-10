using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenuHandler : MonoBehaviour
{
    [SerializeField] private ScreenFader screenFader;

    public void ContinueSaved()
    {
        // This can load a scene that allows the player to select a map
        SceneManager.LoadScene("MapChoicesSaved"); 
    }
    public void Restart()
    {
        // This can load a scene that allows the player to select a map
        SceneManager.LoadScene("MapChoicesNew"); 
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
