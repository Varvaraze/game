using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class UIManager111 : MonoBehaviour
{
    public static UIManager111 Instance;

    [Header("UI элементы")]
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI messageText;
    public Image[] inventorySlots;
    public Image fadeImage;
    public CanvasGroup fadeGroup;

    [Header("Спрайты предметов")]
    public Sprite bandageSprite;
    public Sprite iodineSprite;
    public Sprite antibioticSprite;

    void Awake()
    {
        // Реализуем паттерн Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект между сценами
        }
        else
        {
            // Уничтожаем дубликаты
            Destroy(gameObject);
        }
    }

    public void UpdateObjective(string objective)
    {
        if (objectiveText != null)
            objectiveText.text = objective;
    }

    public void ShowMessage(string message)
    {
        if (messageText != null)
        {
            StopAllCoroutines();
            StartCoroutine(ShowMessageRoutine(message));
        }
    }

    public void HideMessage()
    {
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        messageText.gameObject.SetActive(false);
    }

    public void UpdateInventory(List<string> items)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < items.Count)
            {
                inventorySlots[i].sprite = GetSpriteForItem(items[i]);
                inventorySlots[i].color = Color.white;
            }
            else
            {
                inventorySlots[i].sprite = null;
                inventorySlots[i].color = new Color(1, 1, 1, 0);
            }
        }
    }

    public Sprite GetSpriteForItem(string itemName)
    {
        switch (itemName)
        {
            case "Бинты": return bandageSprite;
            case "Йод": return iodineSprite;
            case "Антибиотик": return antibioticSprite;
            default: return null;
        }
    }

    public void FadeToBlackAndLoadScene(string sceneName)
    {
        Debug.Log("Запуск FadeAndLoad");
        StartCoroutine(FadeThenLoad(sceneName));
    }

    private IEnumerator FadeThenLoad(string sceneName)
    {
        Debug.Log("Начинаем затемнение");

        float duration = 1.5f;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            fadeGroup.alpha = alpha;

            Debug.Log($"[FADE] alpha = {fadeGroup.alpha} time = {currentTime}");
            currentTime += Time.deltaTime;
            yield return null;
        }

        fadeGroup.alpha = 1f;
        Debug.Log("Затемнение завершено. Загружаем сцену: " + sceneName);

        // теперь можно грузить сцену
        SceneManager.LoadScene(sceneName);
    }


}

