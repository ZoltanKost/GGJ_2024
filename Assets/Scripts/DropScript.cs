using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropScript : MonoBehaviour, IDropHandler
{
    public EventHandler<DropScript> OnJokeDropped;
    public JokePieceSO jokePieceSO{get;private set;}
    public DragScript jokeObject;
    public Image image;
    public bool occupied;
    void Awake(){
        image = GetComponent<Image>();
    }
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
    public void SetJokeSO(JokePieceSO so){
        jokePieceSO = so;
        Debug.Log(name + " Just set SO!");
    }
    public JokePieceSO GetJokeSO(){
        return jokePieceSO;
    }
}