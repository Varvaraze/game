using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Привяжи сюда объект меню через инспектор

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Переключаем активность меню
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}
