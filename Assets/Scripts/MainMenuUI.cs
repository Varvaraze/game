using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button continueButton;

    void OnEnable()
    {
        UpdateContinueButtonVisibility();
    }

    public void UpdateContinueButtonVisibility()
    {
        if (continueButton == null)
        {
            Debug.LogError("Кнопка 'Продолжить' не привязана в инспекторе!");
            return;
        }

        if (SaveManager.Instance != null && SaveManager.Instance.HasSave())
        {
            continueButton.gameObject.SetActive(true);
            Debug.Log("Сохранение найдено — кнопка 'Продолжить' показана.");
        }
        else
        {
            continueButton.gameObject.SetActive(false);
            Debug.Log("Сохранений нет — кнопка 'Продолжить' скрыта.");
        }
    }

    public void ContinueGame()
    {
        string savedScene = SaveManager.Instance.GetSavedScene();

        if (!string.IsNullOrEmpty(savedScene))
        {
            SceneManager.LoadScene(savedScene);
        }
        else
        {
            Debug.LogWarning("Сохранённой сцены нет, загрузка невозможна.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
