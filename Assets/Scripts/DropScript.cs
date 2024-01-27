using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropScript : MonoBehaviour, IDropHandler
{
    public EventHandler<DropScript> OnJokeDropped;
    public JokePieceSO jokePieceSO{get;private set;}
    public Image image;
    void Awake(){
        image = GetComponent<Image>();
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=GetComponent<RectTransform>().anchoredPosition;
        OnJokeDropped?.Invoke(this,this);
    }
    public void SetJokeSO(JokePieceSO so){
        jokePieceSO = so;
        Debug.Log(name + " Just set SO!");
    }
    public JokePieceSO GetJokeSO(){
        return jokePieceSO;
    }
}