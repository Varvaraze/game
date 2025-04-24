using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager3.Instance.GameOver(); // �������, ��� ��� � ������ � Player
        }
    }
}
