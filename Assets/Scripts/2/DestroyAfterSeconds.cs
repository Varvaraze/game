using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float seconds = 3f;

    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
