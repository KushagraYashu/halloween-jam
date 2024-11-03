using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
    public static GameManager Instance;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public int playerScore;
    public GameObject player;
    public GameObject candySoundGO;
    public ScoreManager scoreManager;
    public GooRise goo;

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
        Debug.Log("gameover called");
        scoreText.text = "Final Score: " + (int)scoreManager.score;
        player.GetComponent<PlayerController>().enabled = false;
        audioManager.loopAudioSource.Stop();
        player.GetComponent<AudioSource>().Play();
        // Add any additional code for stopping player control or pausing the game here.
    }
}
