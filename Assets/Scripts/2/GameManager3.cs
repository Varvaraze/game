using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 Instance;

    public GameObject gameOverCanvasPrefab; // Ссылка на префаб с Canvas и изображением GameOver

    private GameObject gameOverCanvas;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Этот объект не уничтожится при смене сцены
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameOverCanvas == null) // Если Canvas еще не был создан
        {
            // Создаем новый Canvas с картинкой GameOver
            gameOverCanvas = Instantiate(gameOverCanvasPrefab);
            DontDestroyOnLoad(gameOverCanvas); // Убедитесь, что Canvas не уничтожается при смене сцены

            // Скрыть картинку при первой загрузке сцены
            gameOverCanvas.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("💀 Игрок погиб! Перезапуск через 3 секунды...");

            if (gameOverCanvas != null)
                gameOverCanvas.SetActive(true); // Показать картинку

            Invoke("RestartScene", 3f); // Задержка перед перезапуском сцены (3 секунды)
        }
    }

    private void RestartScene()
    {
        isGameOver = false;

        // Скрываем картинку "Game Over" перед перезапуском сцены
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
