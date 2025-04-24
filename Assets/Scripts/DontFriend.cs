using UnityEngine;

public class DontFriend : MonoBehaviour
{
    public GameObject dontFriendPanel; // ������ ��� NPC, ���� ��� �� "����"

    // ���� ����� ����� ���������� ��� ����� ������ � ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ������ �� ������ ������������ ��� �����, ������ ��� ������� T
            dontFriendPanel.SetActive(false); // ���������, ��� ������ ���������� ������
        }
    }

    // ���� ����� ����� ���������� ��� ������ ������ �� ����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dontFriendPanel.SetActive(false); // �������� ������ ��� ������
        }
    }
}
