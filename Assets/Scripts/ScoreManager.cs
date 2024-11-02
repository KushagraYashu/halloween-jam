using UnityEngine;
using TMPro; // Include TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public float score; // The player's current score
    public float scoreIncreaseRate = 0.1f; // Rate at which score increases per second
    public float candyScoreValue = 10f; // Score value for picking up a candy
    private bool isGameActive = true; // To control when the score is updating

    void Start()
    {
        // Initialize score text
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        // Update the score while the game is active
        if (isGameActive)
        {
            score += scoreIncreaseRate * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void AddScoreForCandy()
    {
        // Increase score by candy score value
        score += candyScoreValue;
    }

    public void SetGameActive(bool active)
    {
        isGameActive = active;
    }
}
