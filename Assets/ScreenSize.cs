using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    void Start()
    {
        // Get the width and height of the screen in pixels
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        Debug.Log("Screen width: " + screenWidth + " pixels");
        Debug.Log("Screen height: " + screenHeight + " pixels");

        // Alternatively, you can get the screen size in inches
        float screenInchesWidth = screenWidth / Screen.dpi;
        float screenInchesHeight = screenHeight / Screen.dpi;

        Debug.Log("Screen width: " + screenInchesWidth + " inches");
        Debug.Log("Screen height: " + screenInchesHeight + " inches");

        // You can also get the aspect ratio of the screen
        float aspectRatio = (float)screenWidth / screenHeight;
        Debug.Log("Screen aspect ratio: " + aspectRatio);
    }
}
