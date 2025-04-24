using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Ссылка на Canvas с меню паузы (его можно создать через UI -> Canvas)
    public GameObject pauseMenu;
    // Флаг, показывающий, находится ли игра в режиме паузы
    private bool isPaused = false;

    void Update()
    {
        // Если нажата клавиша Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    // Метод для возобновления игры
    public void Resume()
    {
        pauseMenu.SetActive(false); // Скрываем меню
        Time.timeScale = 1f;          // Возобновляем время игры
        isPaused = false;
    }

    // Метод для постановки игры на паузу
    void Pause()
    {
        pauseMenu.SetActive(true); // Показываем меню
        Time.timeScale = 0f;         // Останавливаем время игры
        isPaused = true;
    }
}
