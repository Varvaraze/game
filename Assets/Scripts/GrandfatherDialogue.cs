using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GrandfatherDialogue : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI speakerNameText;
    public GameObject backgroundImage;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Button nextButton;
    public Image fadeImage;
    public GameObject taskPanel;
    public GameObject exitButton;
    public GameObject bucket;

    [Header("Settings")]
    public float delayBeforeStart = 2f;
    public float typingSpeed = 0.05f;
    public float fadeSpeed = 1.5f;
    public string nextSceneName;

    private Queue<DialogueLine> sentences;
    private bool isTyping = false;
    private bool canExit = false;

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
        fadeImage.color = new Color(1, 1, 1, 0);

        if (taskPanel != null)
        {
            taskPanel.SetActive(false);
            DontDestroyOnLoad(taskPanel);
        }

        if (exitButton != null) exitButton.SetActive(false);
        if (bucket != null)
        {
            bucket.SetActive(false);
            DontDestroyOnLoad(bucket);
        }

        StartDialogueOnSceneLoad();
    }

    public void StartDialogueOnSceneLoad()
    {
        StartCoroutine(StartDialogueWithDelay());
    }

    IEnumerator StartDialogueWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        StartDialogue(new DialogueLine[]
        {
            new DialogueLine { speaker = "Дедушка", sentence = "О, внучек, хорошо, что пришёл." },
            new DialogueLine { speaker = "Дедушка", sentence = "Мне нужна вода, принеси её из колодца, пожалуйста." }
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
            EndDialogue();
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

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (taskPanel != null)
        {
            taskPanel.SetActive(true);
            UpdateTaskPanelText("Задание: Принеси ведро воды");
        }

        if (exitButton != null) exitButton.SetActive(true);
        if (bucket != null) bucket.SetActive(true);

        GameFlags.taskGiven = true;
        canExit = true;

        Debug.Log("Задание выдано!");
    }

    void UpdateTaskPanelText(string message)
    {
        if (taskPanel != null)
        {
            TextMeshProUGUI taskText = taskPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (taskText != null)
            {
                taskText.text = message;
            }
        }
    }

    void Update()
    {
        if (canExit && Input.GetKeyDown(KeyCode.E))
        {
            FadeToWhite();
        }
    }

    void FadeToWhite()
    {
        if (backgroundImage != null)
        {
            backgroundImage.SetActive(true);
        }
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

        SceneManager.LoadScene(nextSceneName);
    }
}
