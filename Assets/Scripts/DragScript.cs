using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    public EventHandler<DragScript> OnDragBegin;
    public EventHandler<DragScript> OnDragEnd;
    private DropScript currentSlot;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;
    [SerializeField] CanvasGroup canvasGroup;

    public bool HasScoredPoints => _hasScoredPoints;

    RectTransform rec;
    Canvas canvas;
    
    bool _hasScoredPoints;

    public JokePieceSO jokePieceSO{get;private set;}

    void Awake()
    {
        rec = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        currentSlot.ResetJokeObject();
        OnDragBegin?.Invoke(this,this);
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
        OnDragEnd?.Invoke(this,this);
        image.raycastTarget = true;
        // img.enabled = true;
    }
    public void SetJokePiece(JokePieceSO piece){
        jokePieceSO = piece;
        Debug.Log(piece != null);
        text.text = jokePieceSO.text;
    }
    public JokePieceSO GetJokeSO(){
        return jokePieceSO;
    }
    public void SetParentSlot(DropScript parent){
        currentSlot?.ResetJokeObject();
        currentSlot = parent;
        ResetPosition();
    }
    public void ResetPosition(){
        rec.anchoredPosition = currentSlot.GetComponent<RectTransform>().anchoredPosition;
    }

    public void SetHasScoredPoints()
    {
        _hasScoredPoints = true;
        canvasGroup.alpha = 0.65f;
    }
}