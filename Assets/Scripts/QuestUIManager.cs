using UnityEngine;
using UnityEngine.UI;  // Используем стандартный UI Text

public class QuestUIManager : MonoBehaviour
{
    public Text taskText;  // Используем стандартный Text для UI текста

    void Start()
    {
        // Проверяем, если taskText не null
        if (taskText != null)
        {
            taskText.text = "Задание: Принести ведро воды";  // Обновляем текст при старте
        }
    }

    public void CompleteTask()
    {
        if (taskText != null)
        {
            taskText.text = "Задание выполнено!";  // Меняем текст на "Задание выполнено!"
        }
    }
}
