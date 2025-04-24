using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneIntro : MonoBehaviour
{
    public CanvasGroup whiteScreen;  // Белая картинка
    public CanvasGroup startScreen;  // Картинка с надписью
    public float fadeDuration = 2f;  // Время появления/исчезновения

    void Start()
    {
        // Устанавливаем изначальные состояния
        whiteScreen.alpha = 1f;  // Белый экран сразу виден
        startScreen.alpha = 0f;  // Картинка с надписью скрыта

        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // Ждём 2 секунды на белом экране
        yield return new WaitForSeconds(2f);

        // Плавное появление экрана с надписью
        yield return StartCoroutine(FadeIn(startScreen));

        // Оставить текст на экране 3 секунды
        yield return new WaitForSeconds(3f);

        // Оба экрана исчезают одновременно
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

        // Полностью скрываем оба экрана
        whiteScreen.alpha = 0f;
        startScreen.alpha = 0f;
        whiteScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
    }
}
