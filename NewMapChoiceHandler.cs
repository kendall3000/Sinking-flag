using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class NewMapChoiceHandler : MonoBehaviour
{
    public string[] forestMaps = { "MapForest1", "MapForest2", "MapForest3" };
    public string[] volcanoMaps = { "MapVolcano1", "MapVolcano2", "MapVolcano3" };
    public string[] underwaterMaps = { "MapUnderwater1", "MapUnderwater2", "MapUnderwater3" };
    public string[] laboratoryMaps = { "MapLaboratory1", "MapLaboratory2", "MapLaboratory3" };


    public void LoadRandomMap(string mapType)
    {
        string[] selectedArray;
        switch (mapType)
        {
            case "Forest":
                selectedArray = forestMaps;
                break;
            case "Volcano":
                selectedArray = volcanoMaps;
                break;
            case "Underwater":
                selectedArray = underwaterMaps;
                break;
            case "Laboratory":
                selectedArray = laboratoryMaps;
                break;
            default:
                Debug.LogError("Invalid map type specified.");
                return;
        }

        if (selectedArray.Length == 0)
        {
            Debug.LogError("No maps available in the selected category.");
            return;
        }

        int index = Random.Range(0, selectedArray.Length);
        Time.timeScale = 1;
        SceneManager.LoadScene(selectedArray[index]);
    }
}
