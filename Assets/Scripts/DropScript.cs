using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropScript : MonoBehaviour, IDropHandler
{
    public EventHandler<DropScript> OnJokeDropped;
    public JokePieceSO jokePieceSO{get;private set;}
    public DragScript jokeObject;
    public bool occupied;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if(occupied) return;
        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
        OnJokeDropped?.Invoke(this,this);
    }
    public void SetJokeObject(DragScript dragScript){
        jokeObject = dragScript;
        jokePieceSO = jokeObject.GetJokeSO();
        occupied = true;
    }
    public void ResetJokeObject(){
        jokeObject = null;
        occupied = false;
    }
    public JokePieceSO GetJokeSO(){
        return jokePieceSO;
    }
}