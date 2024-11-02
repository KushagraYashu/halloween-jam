using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource countdownAudioSource;  // Audio source for countdown
    public AudioSource loopAudioSource;       // Audio source for looping background music

    public AudioClip countdownClip;           // Countdown audio clip
    public AudioClip loopClip;                // Looping audio clip

    private void Start()
    {
        PlayCountdown();
    }

    private void PlayCountdown()
    {
        countdownAudioSource.clip = countdownClip;
        countdownAudioSource.Play();

        // Start the main loop 0.2 seconds before countdown finishes
        Invoke(nameof(StartLoop), countdownClip.length - 0.99f);
    }

    private void StartLoop()
    {
        loopAudioSource.clip = loopClip;
        loopAudioSource.loop = true;          // Enable looping
        loopAudioSource.Play();
    }

    public void StopLoop()
    {
        loopAudioSource.Stop();
    }
}
