using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    [SerializeField] private DialogueTrigger firstDialogue;
    [SerializeField] private MinigameController minigame;
    [SerializeField] private DialogueTrigger secondDialogue;

    [SerializeField] private DialogueManager dialogueManager;

    private void FirstDialogueToMinigame()
    {
        minigame.gameObject.SetActive(true);
        
    }
} 
