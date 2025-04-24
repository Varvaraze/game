using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneIntro : MonoBehaviour
{
    public CanvasGroup whiteScreen;  // ����� ��������
    public CanvasGroup startScreen;  // �������� � ��������
    public float fadeDuration = 2f;  // ����� ���������/������������

    void Start()
    {
        // ������������� ����������� ���������
        whiteScreen.alpha = 1f;  // ����� ����� ����� �����
        startScreen.alpha = 0f;  // �������� � �������� ������

        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // ��� 2 ������� �� ����� ������
        yield return new WaitForSeconds(2f);

        // ������� ��������� ������ � ��������
        yield return StartCoroutine(FadeIn(startScreen));

        // �������� ����� �� ������ 3 �������
        yield return new WaitForSeconds(3f);

        // ��� ������ �������� ������������
        yield return StartCoroutine(FadeOutTogether());
    }

    IEnumerator FadeIn(CanvasGroup canvas)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvas.alpha = elapsedTime / fadeDuration;
            yield return null;
        }
        canvas.alpha = 1f;
    }

    IEnumerator FadeOutTogether()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - (elapsedTime / fadeDuration);
            whiteScreen.alpha = alpha;
            startScreen.alpha = alpha;
            yield return null;
        }

        // ��������� �������� ��� ������
        whiteScreen.alpha = 0f;
        startScreen.alpha = 0f;
        whiteScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
    }
}
