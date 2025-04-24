using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Для перехода между сценами

public class DialogueManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI speakerNameText; // Имя говорящего
    public TextMeshProUGUI dialogueText;    // Текст диалога
    public GameObject dialoguePanel;        // Панель диалога
    public Button nextButton;               // Кнопка "Далее"
    public Image fadeImage;                 // Белый экран для плавного перехода

    [Header("Settings")]
    public float delayBeforeStart = 9f;     // Задержка перед началом
    public float typingSpeed = 0.05f;       // Скорость печатания текста
    public float fadeSpeed = 1.5f;          // Скорость появления белого экрана
    public string nextSceneName;            // Имя следующей сцены

    private Queue<DialogueLine> sentences;  // Очередь реплик
    private bool isTyping = false;          // Флаг, идёт ли печатание
    private bool isEndOfDialogue = false;   // Флаг завершения диалога

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
        fadeImage.color = new Color(1, 1, 1, 0); // Начинаем с прозрачного экрана
        StartCoroutine(StartDialogueWithDelay());
    }

    IEnumerator StartDialogueWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        StartDialogue(new DialogueLine[]
        {
            new DialogueLine { speaker = "Внук", sentence = "Деда, а кем ты был во время войны?" },
            new DialogueLine { speaker = "Дедушка", sentence = "Война началась, когда мне было всего десять лет." },
            new DialogueLine { speaker = "Дедушка", sentence = "Конечно, я не был солдатом, но мы, дети, тоже старались помочь." },
            new DialogueLine { speaker = "Дедушка", sentence = "Мы помогали, как могли..." }
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
