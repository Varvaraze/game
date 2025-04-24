using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Добавляем для перехода между сценами

public class TaskCompletion : MonoBehaviour
{
    public TextMeshProUGUI taskText; // Ссылка на текст панели игрока
    private bool taskCompleted = false;

    public static TaskCompletion Instance;

    void Awake()
    {
        // Singleton, чтобы обращаться из других скриптов
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("TaskCompletion Instance already exists!");
            Destroy(gameObject);
        }
    }

    // Вызывается при выполнении задания
    public void CompleteTask()
    {
        if (taskCompleted) return;

        taskCompleted = true;

        if (taskText != null)
        {
            taskText.text = "Задание выполнено!";
        }

        GameObject bucket = GameObject.FindWithTag("Bucket");
        if (bucket != null)
        {
            bucket.SetActive(false);
            Debug.Log("Ведро скрыто.");
        }
        else
        {
            Debug.LogWarning("Ведро не найдено! Убедись, что у ведра тег 'Bucket'");
        }

        // Переход на другую сцену через 2 секунды
        Invoke("LoadNextScene", 2f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Scene1.1.1"); // Замени "NextScene" на имя нужной тебе сцены!
    }
}
