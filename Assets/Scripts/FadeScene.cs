using UnityEngine;
using System.Collections;

public class FadeScene : MonoBehaviour
{
    public CanvasGroup firstImage;
    public CanvasGroup secondImage;
    public float fadeDuration = 5f;  // ����� ��������� � ������������
    public float displayTime = 3f;   // �����, ���� ����� ������ ��������

    void Start()
    {
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        // 1. ������ �������� ���������� ��������
        yield return StartCoroutine(FadeIn(firstImage));

        // 2. ������ ������ �������� �� ������
        yield return new WaitForSeconds(displayTime);

        // 3. ������ �������� ��������
        yield return StartCoroutine(FadeOut(firstImage));

        // 4. ������ �������� ����������
        yield return StartCoroutine(FadeIn(secondImage));
    }

    IEnumerator FadeIn(CanvasGroup image)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            image.alpha = elapsedTime / fadeDuration;
            yield return null;
        }
        image.alpha = 1f;
    }

    IEnumerator FadeOut(CanvasGroup image)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            image.alpha = 1f - (elapsedTime / fadeDuration);
            yield return null;
        }
        image.alpha = 0f;
    }
}
