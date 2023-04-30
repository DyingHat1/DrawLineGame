using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LineSpawner : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction StartLine;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartLine.Invoke();
    }
}
    
