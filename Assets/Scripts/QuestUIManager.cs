using UnityEngine;
using UnityEngine.UI;  // ���������� ����������� UI Text

public class QuestUIManager : MonoBehaviour
{
    public Text taskText;  // ���������� ����������� Text ��� UI ������

    void Start()
    {
        // ���������, ���� taskText �� null
        if (taskText != null)
        {
            taskText.text = "�������: �������� ����� ����";  // ��������� ����� ��� ������
        }
    }

    public void CompleteTask()
    {
        if (taskText != null)
        {
            taskText.text = "������� ���������!";  // ������ ����� �� "������� ���������!"
        }
    }
}
