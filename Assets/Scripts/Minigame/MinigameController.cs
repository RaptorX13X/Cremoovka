using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private List<PuzzleAnchor> anchors;
    [SerializeField] private GameObject background;
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
        Debug.Log("*moan*");
        background.SetActive(false);
    }
}
