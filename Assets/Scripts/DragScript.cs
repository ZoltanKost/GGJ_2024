using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    public EventHandler<DragScript> OnJokeDrag;
    public EventHandler<DragScript> OnEndJokeDrag;
    private DropScript currentSlot;
    Image image;
    RectTransform rec;
    Canvas canvas;
    public JokePieceSO jokePieceSO{get;private set;}

    void Awake()
    {
        image = GetComponent<Image>();
        rec = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        OnJokeDrag?.Invoke(this,this);
        // img.enabled = false;
        image.raycastTarget = false;
    }
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rec.anchoredPosition+=eventData.delta/canvas.scaleFactor;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Should check if mouse covered DROP
        OnEndJokeDrag?.Invoke(this,this);
        image.raycastTarget = true;
        // img.enabled = true;
    }
    public void SetJokePiece(JokePieceSO piece){
        jokePieceSO = piece;
        Debug.Log(piece != null);
        image.sprite = jokePieceSO.sprite;
    }
    public JokePieceSO GetJokeSO(){
        return jokePieceSO;
    }
    public void SetParentSlot(DropScript parent){
        currentSlot = parent;
        ResetPosition();
    }
    public void ResetPosition(){
        rec.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
    }
}