using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTriggerWalkAndFade : MonoBehaviour
{
    public string sceneToLoad;               // �������� ��������� �����
    public Animator fadeAnimator;            // ������ �� Animator � ��������� Fade
    public float fadeDelay = 1.5f;           // �������� ����� ���������
    public float walkDuration = 2f;          // ������� ������� ����� ����� ���� ���
    public float autoMoveSpeed = 2f;         // �������� ��������������� ��������

    private bool triggered = false;

    private PlayerController2 playerScript;
    private Rigidbody2D playerRb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            playerScript = other.GetComponent<PlayerController2>();
            playerRb = other.GetComponent<Rigidbody2D>();

            if (playerScript != null)
                playerScript.enabled = false; // ��������� ���������� �������

            StartCoroutine(WalkAndFade());
        }
    }

    private System.Collections.IEnumerator WalkAndFade()
    {
        float elapsed = 0f;

        // ������� ������ ��� �� ����
        while (elapsed < walkDuration)
        {
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(autoMoveSpeed, playerRb.linearVelocity.y); // ��� ������
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        // ���������� ������
        if (playerRb != null)
            playerRb.linearVelocity = Vector2.zero;

        // ������ �������� fade
        if (fadeAnimator != null)
            fadeAnimator.SetTrigger("StartFade");

        yield return new WaitForSeconds(fadeDelay);

        // �������� ����� �����
        SceneManager.LoadScene(sceneToLoad);
    }
}
