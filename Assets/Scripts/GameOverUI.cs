using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score text
    public GameObject gameOverPanel; // Reference to the Game Over panel

    private void Start()
    {
        gameOverPanel.SetActive(false); // Hide the Game Over panel at the start
    }

    public void ShowGameOver(int finalScore)
    {
        scoreText.text = "Score: " + finalScore.ToString(); // Update the score text
        gameOverPanel.SetActive(true); // Show the Game Over panel
    }
}
