using UnityEngine;
using UnityEngine.Events;

public class UnityActionInteractable : AInteractable
{
    [SerializeField] UnityEvent<PlayerController> invoker;
    [SerializeField] string labelGerman;
    [SerializeField] string labelEnglish;

    public override string UILabel => LanguageScript.CurrentLanguageStatic switch
    {
        Language.German => labelGerman,
        Language.Englisch => labelEnglish,
        _ => throw new System.NotImplementedException(),
    };

    public override void Interact(PlayerController interactor)
    {
        invoker.Invoke(interactor);
    }
}
