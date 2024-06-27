using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryObject : MonoBehaviour
{
    [SerializeField] private DialogueTrigger memoryDialogue;
    [SerializeField] private GameObject interactInfo;

    private bool inRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            interactInfo.SetActive(true);
            inRange = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            interactInfo.SetActive(false);
            inRange = false;
        }
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            memoryDialogue.TriggerDialogue();
            interactInfo.SetActive(false);
            inRange = false;
        }
    }
}