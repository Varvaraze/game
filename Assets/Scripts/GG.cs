using UnityEngine;
using UnityEngine.SceneManagement;

public class GG : MonoBehaviour
{
    public void GameOver()
    {
        Debug.Log("������ ��������! ���������� ������...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelComplete()
    {
        Debug.Log("������ ������� ����������!");
        // ������ ������� �� ��������� ������� ��� ����� ������.
    }
}
