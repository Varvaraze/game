using UnityEngine;

public class BucketManager : MonoBehaviour
{
    private static BucketManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем ведро при смене сцены
        }
        else
        {
            Destroy(gameObject); // Если ведро уже есть, новое удаляем
        }
    }
}
