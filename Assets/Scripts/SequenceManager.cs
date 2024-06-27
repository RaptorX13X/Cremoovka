using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    [SerializeField] private DialogueTrigger firstDialogue;
    [SerializeField] private MinigameController minigame;
    [SerializeField] private DialogueTrigger secondDialogue;
    [SerializeField] private bool isActuallySecond;

    [SerializeField] private SequenceManager nextMemorySequence;

    private void Update()
    {
        if (firstDialogue.isComplete() && !minigame.isComplete && !secondDialogue.isComplete() && !isActuallySecond)
        {
            FirstDialogueToMinigame();
        }
        
        else if (firstDialogue.isComplete() && isActuallySecond)
        {
            
        }
        // else if (firstDialogue.isComplete() && minigame.isComplete && !secondDialogue.isComplete())
        // {
        //     secondDialogue.TriggerDialogue();
        // }
        // else if (firstDialogue.isComplete() && minigame.isComplete && secondDialogue.isComplete())
        // { 
        //     //TO DO: turn on the next sequence manager
        // }
    }

    private void FirstDialogueToMinigame()
    {
        minigame.StartMinigame();
    }
} 
