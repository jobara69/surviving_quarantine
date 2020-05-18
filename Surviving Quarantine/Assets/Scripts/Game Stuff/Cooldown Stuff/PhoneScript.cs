using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhoneScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Cellphone cell;
    [SerializeField] private Image cellphoneImage;

    public UnityEvent onLongClick;
    private bool isActive;

    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
        cellphoneImage.color = new Color(Mathf.Lerp(0.3261f, 0.5186f, 0.1f), Mathf.Lerp(0.3261f, 0.5186f, 0.1f), Mathf.Lerp(0.3261f, 0.5186f, 0.1f), 0.5f);
        Debug.Log("Pointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
        cellphoneImage.color = new Color(0.5186f, 0.5186f, 0.5186f, 0.5f);
        Debug.Log("Pointer up");
    }

    private void Update()
    {
        if (isActive)
        {
            cell.Interaction();
        }
    }
}
