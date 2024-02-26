using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AK.Wwise.Event MouseHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseHover.Post(gameObject);
    }
}
