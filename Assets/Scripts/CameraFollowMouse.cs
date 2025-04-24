using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float followSpeed = 5f;          // Насколько быстро камера догоняет
    public float cameraZOffset = -10f;      // Стандартная Z-позиция камеры (для 2D)

    // Границы для мыши
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // Получаем позицию мыши в мировых координатах
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ограничиваем положение мыши по осям X и Y в пределах границ
        mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, minX, maxX);
        mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, minY, maxY);

        // Делаем нужный Z, чтобы камера не прыгала
        mouseWorldPos.z = cameraZOffset;

        // Плавно двигаем камеру
        Camera.main.transform.position = Vector3.Lerp(
            Camera.main.transform.position,
            mouseWorldPos,
            followSpeed * Time.deltaTime
        );

        // Показываем в консоли позицию, куда движется камера
        Debug.Log("Камера двигается к: " + mouseWorldPos);
    }
}
