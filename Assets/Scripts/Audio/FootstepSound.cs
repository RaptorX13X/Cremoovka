using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [Header("Footstep Settings")]
    [SerializeField] private AudioSource footstepSource;
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private AudioClip[] caneClips;
    [SerializeField] private float stepInterval = 0.5f;

    private PlayerMovement playerMovement;
    private float stepTimer;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    /*private void Update()
    {
        if (playerMovement.isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }*/

    public void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int clipIndex = Random.Range(0, footstepClips.Length);
            footstepSource.PlayOneShot(footstepClips[clipIndex]);
        }
    }
    
    public void PlayCane()
    {
        if (caneClips.Length > 0)
        {
            int clipIndex = Random.Range(0, caneClips.Length);
            footstepSource.PlayOneShot(caneClips[clipIndex]);
        }
    }

    
}

