using UnityEngine.EventSystems;

public abstract class AInteractable : UIBehaviour
{
    public abstract string UILabel { get; }

    public abstract void Interact(PlayerController interactor);
}
