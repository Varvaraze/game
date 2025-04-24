using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup blackScreen; // ׸���� �����
    public float fadeDuration = 5f; // ����� �������� ����������
    public string nextSceneName;    // �������� ����� �����
    public AudioSource targetAudio; // ���������� ���� ��� ���������
    public float audioFadeDuration = 3f; // ����� ��������� ������

    void Start()
    {
        blackScreen.alpha = 0f; // ׸���� ����� ������� �������
    }

    public void StartSceneTransition()
    {
        StartCoroutine(FadeOutMusicAndScene());
    }

    IEnumerator FadeOutMusicAndScene()
    {
        StartCoroutine(FadeOutAudio(targetAudio, audioFadeDuration)); // ��������� ����������� �����
        yield return StartCoroutine(FadeToBlackAndLoadScene());
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float duration)
    {
        if (audioSource == null) yield break; // ���� ����� ���, �������

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
