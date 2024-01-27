using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private DragScript prefab;
    [SerializeField] private DropScript[] slots;
    [SerializeField] private Canvas canvas;
    private int currentSlot = 0;
    private DragScript currentPiece;
    [SerializeField] private DropScript[] Calculator_Footer;
    [SerializeField] private JokePieceSO[] jokePieces; 
    void Awake(){
        for(int i = 0; i < jokePieces.Length; i++){
            AddToInventory(jokePieces[i]);
        }
        for(int i = 0; i < Calculator_Footer.Length; i++){
            Calculator_Footer[i].OnJokeDropped += OnJokeDropped;
        }
    }

    public void AddToInventory(JokePieceSO jokePiece){
        DragScript joke = Instantiate(prefab, canvas.transform);
        DropScript slot = slots[currentSlot];
        joke.transform.position = slot.transform.position;
        joke.SetJokePiece(jokePiece);
        joke.SetParentSlot(slot);
        currentSlot++;
        slot.gameObject.SetActive(true);
        slot.OnJokeDropped += OnJokeDropped;
        joke.OnDragBegin += OnDragBegin;
        joke.OnDragEnd += OnDragEnd;
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
