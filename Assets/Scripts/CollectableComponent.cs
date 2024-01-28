using System;
using UnityEngine;

public class Collectable : AInteractable
{
    public static EventHandler<AudioClip> OnCollected;
    [SerializeField] private JokePieceSO JokePieceSO;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] Animator anim;

    public Animator Animator => anim;
    public override string UILabel => "Pick Up";

    public JokePieceSO GetSO(){
        return JokePieceSO;
    }

    public override async void Interact(PlayerController interactor)
    {
        interactor.InventoryHandler.AddToInventory(JokePieceSO);
        gameObject.SetActive(false);

        if (interactor)
        {
            OnCollected?.Invoke(this, JokePieceSO.AudioMain);
        }
        await dialogBox.ShowDialogWithTask("You acquired half a joke!");
       
    }
}