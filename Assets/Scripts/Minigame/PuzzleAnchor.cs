using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleAnchor : MonoBehaviour, IDropHandler
{
    [SerializeField] private int pieceNumber;
    public bool completed;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<PuzzlePiece>().pieceNumber == pieceNumber)
        {
            RectTransform thing = eventData.pointerDrag.GetComponent<RectTransform>();
            thing.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            completed = true;
            Destroy(thing.GetComponent<PuzzlePiece>());
        }
    }
}
