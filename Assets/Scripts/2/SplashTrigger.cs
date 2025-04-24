using UnityEngine;

public class SplashTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            CameraShake.Instance?.Shake(); // Тряска камеры
        }
    }
}
