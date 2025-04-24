using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // ��� �������� ����� �������

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI speakerNameText; // ��� ����������
    public TextMeshProUGUI dialogueText;    // ����� �������
    public GameObject dialoguePanel;        // ������ �������
    public Button nextButton;               // ������ "�����"
    public Image fadeImage;                 // ����� ����� ��� �������� ��������

    [Header("Settings")]
    public float delayBeforeStart = 9f;     // �������� ����� �������
    public float typingSpeed = 0.05f;       // �������� ��������� ������
    public float fadeSpeed = 1.5f;          // �������� ��������� ������ ������
    public string nextSceneName;            // ��� ��������� �����

    private Queue<DialogueLine> sentences;  // ������� ������
    private bool isTyping = false;          // ����, ��� �� ���������
    private bool isEndOfDialogue = false;   // ���� ���������� �������

    [System.Serializable]
    public struct DialogueLine
    {
        public string speaker;
        public string sentence;
    }

    void Start()
    {
        sentences = new Queue<DialogueLine>();
        dialoguePanel.SetActive(false);
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(1, 1, 1, 0); // �������� � ����������� ������
        StartCoroutine(StartDialogueWithDelay());
    }

    IEnumerator StartDialogueWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        StartDialogue(new DialogueLine[]
        {
            new DialogueLine { speaker = "����", sentence = "����, � ��� �� ��� �� ����� �����?" },
            new DialogueLine { speaker = "�������", sentence = "����� ��������, ����� ��� ���� ����� ������ ���." },
            new DialogueLine { speaker = "�������", sentence = "�������, � �� ��� ��������, �� ��, ����, ���� ��������� ������." },
            new DialogueLine { speaker = "�������", sentence = "�� ��������, ��� �����..." }
        });
    }

    public void StartDialogue(DialogueLine[] dialogueLines)
    {
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (DialogueLine line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        nextButton.gameObject.SetActive(false);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTyping) return;

        if (sentences.Count == 0)
        {
            isEndOfDialogue = true;
            nextButton.onClick.RemoveAllListeners();
            nextButton.onClick.AddListener(FadeToWhite);
            nextButton.gameObject.SetActive(true);
            return;
        }



        DialogueLine line = sentences.Dequeue();
        speakerNameText.text = line.speaker;
        StartCoroutine(TypeSentence(line.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        nextButton.gameObject.SetActive(true);
    }

    void FadeToWhite()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
