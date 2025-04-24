using UnityEngine;

public class Interactable111 : MonoBehaviour
{
    public bool hasItem = false;
    public string itemName;

    private bool playerNearby = false;

    private string[] emptyPhrases = new string[]
    {
        "�����...",
        "����� ������ ���.",
        "����� �������.",
        "���... �������, ������.",
        "������ ��������� �� �����."
    };

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (UIManager111.Instance == null)
            {
                Debug.LogWarning("UIManager111.Instance �� ������!");
                return;
            }

            if (GameManagerScene111.Instance == null)
            {
                Debug.LogWarning("GameManagerScene111.Instance �� ������!");
                return;
            }

            if (hasItem)
            {
                GameManagerScene111.Instance.AddItemToInventory(itemName);
                UIManager111.Instance.ShowMessage("�� �����: " + itemName);
                hasItem = false;
            }
            else
            {
                string msg = emptyPhrases[Random.Range(0, emptyPhrases.Length)];
                UIManager111.Instance.ShowMessage(msg);
            }
        }
    }


    // ��� 2D! ���� 3D � ��������� OnTriggerEnter(Collider)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            if (hasItem)
                UIManager111.Instance.ShowMessage("������� E, ����� �����: " + itemName);
            else
                UIManager111.Instance.ShowMessage("������� E ��� �������");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            UIManager111.Instance.HideMessage();
        }
    }
}
