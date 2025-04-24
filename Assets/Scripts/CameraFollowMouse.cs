using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float followSpeed = 5f;          // ��������� ������ ������ ��������
    public float cameraZOffset = -10f;      // ����������� Z-������� ������ (��� 2D)

    // ������� ��� ����
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // �������� ������� ���� � ������� �����������
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������������ ��������� ���� �� ���� X � Y � �������� ������
        mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, minX, maxX);
        mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, minY, maxY);

        // ������ ������ Z, ����� ������ �� �������
        mouseWorldPos.z = cameraZOffset;

        // ������ ������� ������
        Camera.main.transform.position = Vector3.Lerp(
            Camera.main.transform.position,
            mouseWorldPos,
            followSpeed * Time.deltaTime
        );

        // ���������� � ������� �������, ���� �������� ������
        Debug.Log("������ ��������� �: " + mouseWorldPos);
    }
}
