using UnityEngine;
using System.Collections;

public class BulletSpawner3 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject splashEffectPrefab;

    public float spawnInterval = 2f;
    public float spawnY = 10f;
    public float splashY = -3.5f;

    public float spawnXStart = 3f;           // Стартовая позиция
    public float xOffsetPerSpawn = 10f;      // Смещение по X для каждой пары
    public float sideOffset = 2f;            // Расстояние между правой и левой пулей
    public float splashXOffset = 0f;         // Смещение лужи по X

    private float timer;
    private int spawnCount = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;

            float centerX = spawnXStart + xOffsetPerSpawn * spawnCount;

            // 👉 Сперва правая пуля
            SpawnBullet(centerX + sideOffset);

            // ⏱ Потом левая с задержкой
            StartCoroutine(SpawnDelayed(centerX - sideOffset, 0.5f));

            spawnCount++;
        }
    }

    IEnumerator SpawnDelayed(float spawnX, float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnBullet(spawnX);
    }

    void SpawnBullet(float spawnX)
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("🛑 bulletPrefab = null! Отменяю спавн.");
            return;
        }

        // Лужа заранее
        if (splashEffectPrefab != null)
        {
            Vector3 splashPos = new Vector3(spawnX + splashXOffset, splashY, 0);
            Instantiate(splashEffectPrefab, splashPos, Quaternion.identity);
        }

        // Пуля
        Vector3 bulletPos = new Vector3(spawnX, spawnY, 0);
        Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
    }
}
