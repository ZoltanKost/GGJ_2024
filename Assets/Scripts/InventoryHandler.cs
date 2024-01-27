using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private DragScript prefab;
    [SerializeField] private DropScript[] slots;
    [SerializeField] private Canvas canvas;
    private int currentSlot = 0;
    private JokePieceSO currentPiece;
    [SerializeField] private DropScript[] Calculator_Footer;
    [SerializeField] private JokePieceSO jokePieceSO;
    void Awake(){
        for(int i = 0; i < 4; i++){
            AddToInventory(jokePieceSO);
        }
        for(int i = 0; i < Calculator_Footer.Length; i++){
            Calculator_Footer[i].OnJokeDropped += OnJokeDropped;
        }
    }

    public void AddToInventory(JokePieceSO jokePiece){
        DragScript joke = Instantiate(prefab, canvas.transform);
        DropScript slot = slots[currentSlot];
        joke.transform.position = slot.transform.position;
        currentSlot++;
        slot.gameObject.SetActive(true);
        slot.OnJokeDropped += OnJokeDropped;
        joke.OnJokeDrag += OnJokeDrag; 
    }
    void OnJokeDrag(object sender, DragScript script){
        Debug.Log("Drag begun!");
    }
    void OnJokeDropped(object sender, DropScript dropScript){
        for(int i = 0; i < Calculator_Footer.Length; i++){
            if(dropScript == Calculator_Footer[i]){
                Debug.Log("DROPPED");
                Debug.Log(dropScript.jokePieceSO);
            }
        }
    } 
}
