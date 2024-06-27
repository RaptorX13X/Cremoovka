using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private DialogueTrigger startingDialogueTrigger;
    [SerializeField] private DialogueManager dialogueManager;

    private void Start()
    {
        startingDialogueTrigger.TriggerDialogue();
    }

    private void Update()
    {
        if (dialogueManager.isDialogueActive)
        {
            player.enabled = false;
        }
        else
        {
            player.enabled = true;
        }
    }
}
