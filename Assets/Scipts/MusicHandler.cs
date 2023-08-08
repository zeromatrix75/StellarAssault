using System.Collections;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the AudioSource component playing the music
    public AudioClip newMusic; // The new music you want to play
    public float fadeDuration = 2.0f; // Duration of the fade-out effect in seconds
    public float delayTimer = 120.0f;// Delay in seconds before transitioning to new music (2 minutes)


    private float initialVolume; // Store the initial volume of the music

    void Start()
    {
        // Store the initial volume of the music
        initialVolume = musicSource.volume;

        // Start the delay timer
        StartCoroutine(StartTransitionAfterDelay());
    }

    public void TransitionToNewMusic()
    {
        // Start the fade-out effect
        StartCoroutine(FadeOutMusic());
    }

    IEnumerator FadeOutMusic()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new volume using a linear interpolation
            float t = elapsedTime / fadeDuration;
            float newVolume = Mathf.Lerp(initialVolume, 0.0f, t);

            musicSource.volume = newVolume;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the volume is set to zero
        musicSource.volume = 0.0f;

        // Change the music clip to the new one
        musicSource.clip = newMusic;

        // Start playing the new music
        musicSource.Play();

        // Start the fade-in effect
        StartCoroutine(FadeInMusic());
    }

    IEnumerator FadeInMusic()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new volume using a linear interpolation
            float t = elapsedTime / fadeDuration;
            float newVolume = Mathf.Lerp(0.0f, initialVolume, t);

            musicSource.volume = newVolume;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the volume is set to the initial volume
        musicSource.volume = initialVolume;
    }

    IEnumerator StartTransitionAfterDelay()
    {
        yield return new WaitForSeconds(delayTimer);

        // Start the music transition
        TransitionToNewMusic();
    }

}
