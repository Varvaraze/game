using UnityEngine;

public class BucketManager : MonoBehaviour
{
    private static BucketManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ����� ��� ����� �����
        }
        else
        {
            Destroy(gameObject); // ���� ����� ��� ����, ����� �������
        }
    }
}
