using UnityEngine;

public class EasyModeGuy : MonoBehaviour
{
    [SerializeField] GameEndSequence.TextString notEnoughFindingsText;
    [SerializeField] GameEndSequence.TextString easyModeActivateText;
    [SerializeField] GameEndSequence.TextString alreadyEasyModeText;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] SubmitterScript submitter;
    [SerializeField] int minJokesToUnlock = 2;
    [SerializeField] Collectable[] collectables;


    bool _isEasy;

    public void Interact()
    {
        if(_isEasy)
        {
            dialogBox.ShowDialog(alreadyEasyModeText.Text);
            return;
        }

        if(submitter.NumJokesCommited<minJokesToUnlock)
        {
            dialogBox.ShowDialog(notEnoughFindingsText.Text);
            return;
        }

        dialogBox.ShowDialog(easyModeActivateText.Text);
        _isEasy = true;

        foreach(var collectable in collectables)
        {
            collectable.Animator.enabled = true;
        }
    }
}
