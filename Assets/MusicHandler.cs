using System.Collections;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FadeInMusic()
    {
        StartCoroutine(FadeIn(audioSource, fadeDuration));
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut(audioSource, fadeDuration));
    }

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        audioSource.volume = 0;
        audioSource.Play();

        float startVolume = 0;
        float targetVolume = 0.1f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float targetVolume = 0;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
        audioSource.Stop();
    }
}
