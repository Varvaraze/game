using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    public GameObject dontFriendPanel;  // Панель для NPC с тегом DontFriend
    public GameObject friendPanel;      // Панель для NPC с тегом Friend

    private bool isInTriggerZone = false; // Флаг, что игрок в зоне

    void Update()
    {
        // Проверка нажатия T в зоне NPC
        if (isInTriggerZone && Input.GetKeyDown(KeyCode.T))
        {
            if (gameObject.CompareTag("Friend"))
            {
                // Задание выполнено у друга
                TaskCompletion.Instance.CompleteTask();  // Взаимодействие с TaskCompletion для выполнения задания
                Debug.Log("Задание выполнено у друга!");
            }
            else if (gameObject.CompareTag("DontFriend"))
            {
                // Показываем панель с сообщением "Это не мне"
                dontFriendPanel.SetActive(true); // Панель для NPC с тегом DontFriend
                Debug.Log("Это не мне!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = true;
            Debug.Log("Игрок вошел в зону NPC.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInTriggerZone = false;
            dontFriendPanel.SetActive(false); // Скрываем панель для NPC с тегом DontFriend, когда игрок выходит из зоны
            Debug.Log("Игрок вышел из зоны NPC.");
        }
    }
}
