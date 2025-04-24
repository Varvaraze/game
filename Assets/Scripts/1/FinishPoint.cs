using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public string playerTag = "Player";
    public GameManager2 gameManager2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            gameManager2.LevelComplete();
        }
    }
}
