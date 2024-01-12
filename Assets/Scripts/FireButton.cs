using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GunController gunController;
    public void OnPointerDown(PointerEventData eventData)
    {
        gunController.FirePressed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gunController.FireReleased();
    }

}
