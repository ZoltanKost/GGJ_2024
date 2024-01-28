using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameEndSequence : MonoBehaviour
{
    [Serializable]
    class TextString
    {
        [SerializeField] string english;
        [SerializeField] string german;

        public string Text => LanguageScript.CurrentLanguageStatic switch
        {
            Language.German => german,
            Language.Englisch => english,
            _ => throw new NotImplementedException(),
        };
    }

    [SerializeField] TextString intro;
    [SerializeField] TextString text1;
    [SerializeField] TextString notCompletedText;
    [SerializeField] PlayableDirector faceAnimationDirector;
    [SerializeField] Image faceImage;
    [SerializeField] TextString[] resultTexts;
    [SerializeField] Jokemeter jokeMeter;
    [SerializeField] UnityActionInteractable objectToDisableWhenEndingStarts;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] BurgerRain rain;
    [SerializeField] FaceEmotionsSO emotions;
    [SerializeField] SubmitterScript submitterScript;

    private void Awake()
    {
        dialogBox.ShowDialog(intro.Text);
    }

    public async void RunEnd(PlayerController playerController)
    {
        if(!submitterScript.IsComplete)
        {
            dialogBox.ShowDialog(notCompletedText.Text);
            return;
        }

        var blockerKey = new object();
        playerController.BlockInput(blockerKey);
        objectToDisableWhenEndingStarts.gameObject.SetActive(false);
        await dialogBox.ShowDialogWithTask(text1.Text);
        faceImage.sprite = emotions.GetEmotion(jokeMeter.Progress);
        var endText = resultTexts[Mathf.RoundToInt(Mathf.Clamp(jokeMeter.Progress,0f,1f)) * resultTexts.Length];
        faceAnimationDirector.gameObject.SetActive(true);
        faceAnimationDirector.Play();
        faceAnimationDirector.stopped += OnStopped;

        async void OnStopped(PlayableDirector obj)
        {
            faceAnimationDirector.stopped -= OnStopped;
            await dialogBox.ShowDialogWithTask(endText.Text);
            rain.MakeItRain();
            playerController.UnblockInput(blockerKey);
        }
    }
}
