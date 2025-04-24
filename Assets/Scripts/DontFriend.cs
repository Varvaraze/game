using UnityEngine;

public class DontFriend : MonoBehaviour
{
    public GameObject dontFriendPanel; // Панель для NPC, если это не "друг"

    // Этот метод будет вызываться при входе игрока в зону
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Панель не должна показываться при входе, только при нажатии T
            dontFriendPanel.SetActive(false); // Убедитесь, что панель изначально скрыта
        }
    }

    // Этот метод будет вызываться при выходе игрока из зоны
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dontFriendPanel.SetActive(false); // Скрываем панель при выходе
        }
    }
}
