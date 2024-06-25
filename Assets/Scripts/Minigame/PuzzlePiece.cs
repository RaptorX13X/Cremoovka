using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PuzzlePiece : MonoBehaviour
{
    //chuj ci w dupe ;3
    [SerializeField] private GameObject correctAnchor;
    [SerializeField] private RectTransform rectTransform;
    private float pieceWidth;
    private float pieceHeight;
    private Vector2 mousePos;
    public bool attached;

    private void Start()
    {
        attached = false;
        pieceWidth = rectTransform.rect.width;
        pieceHeight = rectTransform.rect.height;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Debug.Log(mousePos);
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attached = true;
        }
        if (attached)
        {   
            rectTransform.anchoredPosition = mousePos - new Vector2(960f, 540f);
        }
    }

    
}
