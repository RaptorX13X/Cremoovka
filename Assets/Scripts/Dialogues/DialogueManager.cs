using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.08f;

    public Animator animator;

    public Button button1;
    public Button button2;

    private DialogueSO currentDialogue; 
    private DialogueLine currentLine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        isDialogueActive = true;

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            if (!HandleChoice(currentLine)) 
            {
                EndDialogue();
            }
            return;
        }

        currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        if (currentLine.hasChoices)
        {
            dialogueArea.gameObject.SetActive(false);
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            
            button1.GetComponentInChildren<TextMeshProUGUI>().text = currentLine.choice1;
            button2.GetComponentInChildren<TextMeshProUGUI>().text = currentLine.choice2;

            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();

            button1.onClick.AddListener(() => OnChoiceSelected(currentLine.dialoguetoStartOn1));
            button2.onClick.AddListener(() => OnChoiceSelected(currentLine.dialoguetoStartOn2));

            return;
        }

        dialogueArea.gameObject.SetActive(true);
        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    private bool HandleChoice(DialogueLine line)
    {
        if (line != null && line.hasChoices)
        {
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);

            button1.GetComponentInChildren<TextMeshProUGUI>().text = line.choice1;
            button2.GetComponentInChildren<TextMeshProUGUI>().text = line.choice2;

            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();

            button1.onClick.AddListener(() => OnChoiceSelected(line.dialoguetoStartOn1));
            button2.onClick.AddListener(() => OnChoiceSelected(line.dialoguetoStartOn2));

            return true;
        }
        return false;
    }

    private void OnChoiceSelected(DialogueSO nextDialogue)
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        if (nextDialogue != null)
        {
            StartDialogue(nextDialogue);
        }
        else
        {
            DisplayNextDialogueLine();
        }
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        
        animator.Play("hide");
    }
}