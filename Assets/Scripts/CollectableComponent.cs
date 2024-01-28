using UnityEngine;

public class Collectable : AInteractable
{
    [SerializeField] private JokePieceSO JokePieceSO;
    [SerializeField] DialogBox dialogBox;

    public override string UILabel => "Pick Up";

    public JokePieceSO GetSO(){
        return JokePieceSO;
    }

    public override async void Interact(PlayerController interactor)
    {
        interactor.InventoryHandler.AddToInventory(JokePieceSO);
        gameObject.SetActive(false);
        await dialogBox.ShowDialogWithTask("You acquired half a joke!");
        
        if(interactor)
        {
            var asource = interactor.gameObject.AddComponent<AudioSource>();
            asource.clip = JokePieceSO.AudioMain;
            asource.Play();
            Destroy(asource,12f);
        }
    }
}