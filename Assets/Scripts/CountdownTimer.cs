using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Reference to the TextMeshProUGUI component
    public float countdownTime = 1f; // Time in seconds between each countdown step
    public GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(countdownTime);

        countdownText.text = "2";
        yield return new WaitForSeconds(countdownTime);

        countdownText.text = "1";
        yield return new WaitForSeconds(countdownTime);

        countdownText.text = "GO!";
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
        yield return new WaitForSeconds(countdownTime);

        countdownText.text = ""; // Clear the text after "GO!"
        
    }
}
