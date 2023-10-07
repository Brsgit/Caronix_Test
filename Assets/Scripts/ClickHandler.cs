using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour , IPointerDownHandler
{
    public event Action OnImageClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnImageClick?.Invoke();
    }
}
