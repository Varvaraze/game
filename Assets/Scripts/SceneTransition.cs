using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup blackScreen; // Чёрный экран
    public float fadeDuration = 5f; // Время плавного затемнения
    public string nextSceneName;    // Название новой сцены
    public AudioSource targetAudio; // Конкретный звук для затухания
    public float audioFadeDuration = 3f; // Время затухания музыки

    void Start()
    {
        blackScreen.alpha = 0f; // Чёрный экран сначала невидим
    }

    public void StartSceneTransition()
    {
        StartCoroutine(FadeOutMusicAndScene());
    }

    IEnumerator FadeOutMusicAndScene()
    {
        StartCoroutine(FadeOutAudio(targetAudio, audioFadeDuration)); // Затухание конкретного звука
        yield return StartCoroutine(FadeToBlackAndLoadScene());
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float duration)
    {
        if (audioSource == null) yield break; // Если звука нет, выходим

        float startVolume = audioSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / duration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }

    IEnumerator FadeToBlackAndLoadScene()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.alpha = elapsedTime / fadeDuration;
            yield return null;
        }

        blackScreen.alpha = 1f;
        SceneManager.LoadScene(nextSceneName);
    }
}
