using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image rightButton;
    [SerializeField] private SpaceMoviment moviment;

    public void OnPointerDown(PointerEventData eventData)
    {
        moviment.h_move = 1;
        rightButton.color = new Color(Mathf.Lerp(0.4940f, 1f, 0.1f), Mathf.Lerp(0.4940f, 1f, 0.1f), Mathf.Lerp(0.4940f, 1f, 0.1f), 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moviment.h_move = 0;
        rightButton.color = new Color(1f, 1f, 1f, 1f);
    }
}
