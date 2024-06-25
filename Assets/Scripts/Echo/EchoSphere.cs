using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSphere : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float timeToWaitStepToEcho = 0.5f;
    [SerializeField] private float timeToWaitEchoToStep = 0.5f;
    [SerializeField] private float spherecastRadius = 10f;
    [SerializeField] private LayerMask echoLayer;

    private void Update()
    {
        if (playerMovement.isMoving)
        {
            StartCoroutine(Moving());
        }
        else
        {
            StopCoroutine(Moving());
        }
    }

    IEnumerator Moving()
    {
        //play stepping sound
        yield return new WaitForSeconds(timeToWaitStepToEcho);
        //play echo sound
        //spherecast layer/tag shaderobject
        //turn on shaders
        //turn on their scripts to turn off shaders
        yield return new WaitForSeconds(timeToWaitEchoToStep);
    }
}
