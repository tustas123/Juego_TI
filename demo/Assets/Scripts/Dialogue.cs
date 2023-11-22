using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialogueMark;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.05f;


    private bool isPlayerInrange;
    private bool didDialogueStart;
    private int lineIndex;

    void Update()
    {
        if (isPlayerInrange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }

        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        DialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());

        }
        else
        {
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrange = true;
            DialogueMark.SetActive(true);
            //Debug.Log("Se pude iniciar un dialogo");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInrange = false;
            DialogueMark.SetActive(false);
            //ebug.Log("NO se pude iniciar un dialogo");
        }

    }
}