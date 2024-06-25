using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSphere : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float timeToWaitStepToEcho = 0.5f;
    [SerializeField] private float timeToWaitEchoToStep = 0.5f;
    [SerializeField] private LayerMask echoLayer;
    public List<GameObject> echoObjects;

    private void Start()
    {
       // StartCoroutine(Moving());
    }
    /*private void Update()
    {
        if (playerMovement.isMoving)
        {
            Debug.Log("coroutine starting idk");
            StartCoroutine(Moving());
        }
        else
        {
            Debug.Log("coroutine stopping idk");
            StopCoroutine(Moving());
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == echoLayer)
        {
            echoObjects.Add(other.gameObject);
            Debug.Log("why");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == echoLayer)
        {
            echoObjects.Remove(other.gameObject);
        }
    }

    /*IEnumerator Moving()
    {
        while(playerMovement.isMoving)
        {
            Debug.Log("schmoving");
            //play stepping sound
            yield return new WaitForSeconds(timeToWaitStepToEcho);
            //play echo sound
            foreach (GameObject echoObject in echoObjects)
            {
                if (echoObject == null) continue;
                echoObject.GetComponent<Shutdown>().Fading();
            }
            yield return new WaitForSeconds(timeToWaitEchoToStep);
        }

        yield return new WaitWhile((() => !playerMovement.isMoving));
        StartCoroutine(Moving());
    }*/
}
