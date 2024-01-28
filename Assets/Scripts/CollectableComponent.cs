using UnityEngine;

public class Collectable : AInteractable
{
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
            var asource = interactor.gameObject.AddComponent<AudioSource>();
            asource.clip = JokePieceSO.AudioMain;
            asource.Play();
            Destroy(asource, 12f);
        }
        await dialogBox.ShowDialogWithTask("You acquired half a joke!");
       
    }
}