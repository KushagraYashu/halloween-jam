using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public int playerScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int amount)
    {
        playerScore += amount;
        scoreText.text = "Score: " + playerScore;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        scoreText.text = "Final Score: " + playerScore;
        // Add any additional code for stopping player control or pausing the game here.
    }
}
