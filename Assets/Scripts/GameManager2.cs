using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
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
