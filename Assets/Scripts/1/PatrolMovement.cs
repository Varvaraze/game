using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PatrolMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypoint = 0;

    [Header("Gizmos Settings")]
    public float labelOffset = 0.3f; // �������� ������ ������������ �����
    public Color labelColor = Color.white; // ���� ��������

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0) return;

#if UNITY_EDITOR
        // ����� ��� ��������
        GUIStyle style = new GUIStyle();
        style.normal.textColor = labelColor;
        style.fontSize = 12;
        style.alignment = TextAnchor.MiddleCenter;

        // ������� ��� ����� ����
        string pathLabel = $"{gameObject.name}'s Path";
        Handles.Label(transform.position + Vector3.up * labelOffset, pathLabel, style);

        // ������� ��� ��������� �����
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null) continue;

            string label = $"{gameObject.name}\nPoint {i}";
            Vector3 labelPos = waypoints[i].position + Vector3.up * labelOffset;
            Handles.Label(labelPos, label, style);
        }
#endif

        // ��������� ����� � �����
        Gizmos.color = Color.cyan;
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (waypoints[i] == null) continue;

            Gizmos.DrawSphere(waypoints[i].position, 0.15f);
            if (i < waypoints.Length - 1 && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}