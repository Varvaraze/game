using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public string playerTag = "Player";
    public GameManager2 gameManager2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Игрок обнаружен!");
            gameManager2.GameOver();
        }
    }
}
