using UnityEngine;

public class CameraFollow3 : MonoBehaviour
{
    public Transform target;            // Игрок
    public float followSpeed = 2f;
    public float forwardSpeed = 2f;
    public float yOffset = 2f;

    public Transform wall;              // Стена
    private float wallOffsetX;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        // Камера двигается вперёд по X
        pos.x += forwardSpeed * Time.deltaTime;

        // Плавное движение по Y
        if (target != null)
        {
            float targetY = target.position.y + yOffset;
            pos.y = Mathf.Lerp(pos.y, targetY, followSpeed * Time.deltaTime);
        }

        // Добавляем смещение от тряски камеры (если есть)
        Vector3 shakeOffset = CameraShake.Instance?.GetShakeOffset() ?? Vector3.zero;
        transform.position = pos + shakeOffset;

        // ⬅️ Стена вровень с левым краем камеры
        if (wall != null && cam != null)
        {
            float halfWidth = cam.orthographicSize * cam.aspect;
            wall.position = new Vector3(transform.position.x - halfWidth, wall.position.y, wall.position.z);
        }
    }
}
