using System;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private DragScript prefab;
    [SerializeField] private DropScript[] slots;
    [SerializeField] private Transform InventoryUI;
    private int currentSlot = 0;
    private DragScript currentPiece;
    [SerializeField] private DropScript[] Calculator_Footer;
    [SerializeField] CalculatorHandler handler;
    void Awake(){
        for(int i = 0; i < Calculator_Footer.Length; i++){
            Calculator_Footer[i].OnJokeDropped += OnJokeDropped;
        }

        handler.OnJokeSubmitted += OnJokeSubmitted;
    }

    private void OnJokeSubmitted(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e)
    {
        UnassignAllFooterJokes();
    }

    public void AddToInventory(JokePieceSO jokePiece){
        InventoryUI.gameObject.SetActive(true);
        DragScript joke = Instantiate(prefab, InventoryUI);
        DropScript slot = slots[currentSlot];
        slot.SetJokeObject(joke);
        joke.SetJokePiece(jokePiece);
        joke.SetParentSlot(slot);
        currentSlot++;
        slot.gameObject.SetActive(true);
        slot.OnJokeDropped += OnJokeDropped;
        joke.OnDragBegin += OnDragBegin;
        joke.OnDragEnd += OnDragEnd;
        InventoryUI.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        InventoryUI.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        InventoryUI.gameObject.SetActive(false);
        UnassignAllFooterJokes();
    }

    void UnassignAllFooterJokes()
    {
        foreach (var f in Calculator_Footer)
        {
            if (f.occupied)
            {
                foreach (DropScript s in slots)
                {
                    if (!s.occupied)
                    {
                        s.SetJokeObject(f.GetJokeObject());
                        f.GetJokeObject().SetParentSlot(s);
                        f.ResetJokeObject();
                        break;
                    }
                }
            }
        }
    }

    public void ToggleInventory()
    {
        if(InventoryUI.gameObject.activeSelf)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    void OnDragBegin(object sender, DragScript script){
        Debug.Log("Drag begun!");
        currentPiece = script;
    }
    void OnJokeDropped(object sender, DropScript dropScript){
        dropScript.SetJokeObject(currentPiece);
        currentPiece.SetParentSlot(dropScript);
        currentPiece = null;
    } 
    void OnDragEnd(object sender, DragScript script){
        script.ResetPosition();
    }
}
