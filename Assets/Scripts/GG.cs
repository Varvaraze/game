using UnityEngine;
using UnityEngine.SceneManagement;

public class GG : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("Пойман патрулем! Перезапуск уровня...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete()
    {
        Debug.Log("Письмо успешно доставлено!");
        // Добавь переход на следующий уровень или экран победы.
    }
}
