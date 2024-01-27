using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropScript : MonoBehaviour,IDropHandler
{
    public EventHandler<DropScript> OnJokeDropped;
    public JokePieceSO jokePieceSO{get;private set;}
    public Image image;
    void Awake(){
        image = GetComponent<Image>();
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        OnJokeDropped?.Invoke(this,this);
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
    }
}