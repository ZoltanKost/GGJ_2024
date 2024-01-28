using UnityEngine;

public class Collectable : AInteractable
{
    [SerializeField] private JokePieceSO JokePieceSO;
    [SerializeField] DialogBox dialogBox;

    public override string UILabel => "Pick Up";

    public JokePieceSO GetSO(){
        return JokePieceSO;
    }

    public override void Interact(PlayerController interactor)
    {
        interactor.InventoryHandler.AddToInventory(JokePieceSO);
        dialogBox.ShowDialog("You acuired half a joke!");
        gameObject.SetActive(false);
    }
}