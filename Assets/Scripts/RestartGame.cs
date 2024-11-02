using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Needed for UI components
using System.Collections; // Needed for Coroutine

public class RestartGame : MonoBehaviour
{
    public Image fadeImage; // Assign this in the Inspector
    private bool isRestarting = false;
    public float waitTime = 1.0f; // Time to wait on black screen before restarting

    void Update()
    {
        // Check if the spacebar is pressed and we're not already restarting
        if (Input.GetKeyDown(KeyCode.Space) && !isRestarting)
        {
            StartCoroutine(RestartCurrentScene());
        }
    }

    private IEnumerator RestartCurrentScene()
    {
        isRestarting = true; // Prevent multiple restarts

        // Start the fade in
        yield return StartCoroutine(FadeTo(1f, 1f)); // Fade to black over 1 second

        // Wait for the specified time on the black screen
        yield return new WaitForSeconds(waitTime); // Wait for a moment

        // Get the active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // Start the fade out (optional)
        yield return StartCoroutine(FadeTo(0f, 1f)); // Fade back to transparent over 1 second
        isRestarting = false; // Allow restarts again
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = fadeImage.color.a; // Get current alpha
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            Color newColor = fadeImage.color;
            newColor.a = alpha;
            fadeImage.color = newColor; // Update the panel color
            yield return null; // Wait for the next frame
        }
    }
}
