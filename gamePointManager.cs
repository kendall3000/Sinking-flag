using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePointManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] public TextMeshProUGUI scoreText;  // This should now correctly reference a TextMeshProUGUI

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Detected with: " + other.gameObject.name);  // Check if collisions are detected
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            UpdateScoreDisplay();
            Destroy(other.gameObject);  // Remove the coin from the game
            //Debug.Log("Coin collected. Current Score: " + score);
        }
    }

    void Start() {

        if (scoreText == null) {
            Debug.LogError("scoreText is null on Start");
        } else {
            Debug.Log("scoreText is correctly assigned on Start");
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            //Debug.Log("Updated Score Display to: " + scoreText.text);
        }
        else
        {
            Debug.LogError("Score Text component is not assigned in the Inspector.");
        }
    }
}

