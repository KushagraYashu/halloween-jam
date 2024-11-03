using UnityEngine;
using TMPro; // Include TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI bestScoreText; // Reference to the TextMeshProUGUI component
    public float score; // The player's current score
    public float scoreIncreaseRate = 0.1f; // Rate at which score increases per second
    private bool isGameActive = false; // To control when the score is updating
    public static int lastBestScore;
    public int bestScore;

    private void Awake()
    {
        bestScore = lastBestScore;
        bestScoreText.text = "Best Score: " + Mathf.FloorToInt(bestScore).ToString();
    }

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
            if ((int)score > bestScore) {
                bestScore = (int)score;
                lastBestScore = bestScore;
                bestScoreText.text = "Best Score: " + Mathf.FloorToInt(bestScore).ToString();
            }
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void AddScoreForCandy(int candyScore)
    {
        // Increase score by candy score value
        score += candyScore;
        if ((int)score > bestScore)
        {
            bestScore = (int)score;
            lastBestScore = bestScore;
            bestScoreText.text = "Best Score: " + Mathf.FloorToInt(bestScore).ToString();
        }
    }

    public void SetGameActive(bool active)
    {
        isGameActive = active;
    }

}
