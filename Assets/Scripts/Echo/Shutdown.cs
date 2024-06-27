using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shutdown : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    public void Fading()
    {
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        meshRenderer.enabled = true;
        //set color black
        //dotween fade to white
        yield return new WaitForSeconds(0.75f);
        meshRenderer.enabled = false;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireCube(GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
    // }
}
