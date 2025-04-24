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
            Debug.LogError("������ '����������' �� ��������� � ����������!");
            return;
        }

        if (SaveManager.Instance != null && SaveManager.Instance.HasSave())
        {
            continueButton.gameObject.SetActive(true);
            Debug.Log("���������� ������� � ������ '����������' ��������.");
        }
        else
        {
            continueButton.gameObject.SetActive(false);
            Debug.Log("���������� ��� � ������ '����������' ������.");
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
            Debug.LogWarning("���������� ����� ���, �������� ����������.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
