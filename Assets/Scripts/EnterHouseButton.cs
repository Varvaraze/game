using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseButton : MonoBehaviour
{
    public string houseSceneName = "House2"; // Название сцены дома
    private bool nearDoor = false;

    void Update()
    {
        if (nearDoor && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(houseSceneName); // Переход в дом
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = false;
        }
    }
}
