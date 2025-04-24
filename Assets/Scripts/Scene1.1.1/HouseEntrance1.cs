using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEntrance : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Название сцены, которую загружать
    private bool playerInZone = false;

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            Debug.Log("Игрок подошёл к двери. Нажмите E для входа.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
