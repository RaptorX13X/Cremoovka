using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private List<PuzzleAnchor> anchors;
    [SerializeField] private GameObject background;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private DialogueTrigger continuedDialogue;

    public bool isComplete = false;

    [SerializeField] private GameObject originalMemory;
    [SerializeField] private GameObject newMemory;
    [SerializeField] private GameObject memorySpirit;
    [SerializeField] private AudioClip memoryMusic;
    [SerializeField] private Music player;

    public void StartMinigame()
    {
        background.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        dialogueCanvas.SetActive(false);
        //dialogueManager.isDialogueActive = true;
    }

    private void Update()
    {
        foreach (PuzzleAnchor anchor in anchors)
        {
            if (!anchor.completed)
            {
                return;
            }
        }

        StartCoroutine(PuzzleComplete());
    }

    IEnumerator PuzzleComplete()
    {
        yield return new WaitForSeconds(1f);
        background.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isComplete = true;
        dialogueCanvas.SetActive(true);
        originalMemory.SetActive(false);
        newMemory.SetActive(true);
        memorySpirit.SetActive(true);
        player.PlayMemoryMusic(memoryMusic);
        //dialogueManager.isDialogueActive = false;
    }
}
