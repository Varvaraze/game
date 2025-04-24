using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private Transform camTransform;
    private Vector3 shakeOffset = Vector3.zero;

    void Awake()
    {
        Instance = this;
        camTransform = transform;
    }

    public void Shake(float duration = 0.2f, float magnitude = 0.1f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            shakeOffset = new Vector3(
                Random.Range(-1f, 1f) * magnitude,
                Random.Range(-1f, 1f) * magnitude,
                0f
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        shakeOffset = Vector3.zero;
    }

    public Vector3 GetShakeOffset()
    {
        return shakeOffset;
    }
}
