using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // ������� ���� ������ ���� ����� ���������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ����������� ���������� ����
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }
}
