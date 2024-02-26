using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickSounds : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public AK.Wwise.Event ButtonPressed;
    public AK.Wwise.Event ButtonReleased;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonPressed.Post(gameObject);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonReleased.Post(gameObject);
    }
}
