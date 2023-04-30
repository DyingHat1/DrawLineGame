using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LineEnd : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool _cursorInTheEndZone = false;

    public bool CurosrInTheEndZone => _cursorInTheEndZone;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _cursorInTheEndZone = true;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        _cursorInTheEndZone = false;
    }

    private void OnDisable()
    {
        _cursorInTheEndZone = false;
    }
}
