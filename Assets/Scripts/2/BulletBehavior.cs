using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Камера трясётся при любом столкновении
        CameraShake.Instance?.Shake();

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Игрок получил урон от пули!");
            GameManager3.Instance?.GameOver();
            Destroy(gameObject); // Уничтожаем пулю
        }
        else if (collision.CompareTag("Ground")) // 👈 Назначь лужам тег Ground
        {
            Destroy(gameObject); // Пуля исчезает при попадании в землю
        }
    }

}
