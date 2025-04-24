using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // ������ �� Canvas � ���� ����� (��� ����� ������� ����� UI -> Canvas)
    public GameObject pauseMenu;
    // ����, ������������, ��������� �� ���� � ������ �����
    private bool isPaused = false;

    void Update()
    {
        // ���� ������ ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    // ����� ��� ������������� ����
    public void Resume()
    {
        pauseMenu.SetActive(false); // �������� ����
        Time.timeScale = 1f;          // ������������ ����� ����
        isPaused = false;
    }

    // ����� ��� ���������� ���� �� �����
    void Pause()
    {
        pauseMenu.SetActive(true); // ���������� ����
        Time.timeScale = 0f;         // ������������� ����� ����
        isPaused = true;
    }
}
