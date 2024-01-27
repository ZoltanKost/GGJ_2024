using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    [SerializeField] float charsPerSeconds;
    [SerializeField] PlayerController playerController;
    
    Coroutine _coroutine;

    public void ShowDialog(string text)
    {
        if(_coroutine!=null)
        {
            playerController.UnblockInput(_coroutine);
            StopCoroutine(_coroutine);
        }

        gameObject.SetActive(true);
        tmpText.text = text;
        tmpText.maxVisibleCharacters = 0;

        _coroutine = StartCoroutine(DoShowDialog());
        playerController.BlockInput(_coroutine);
    }

    IEnumerator DoShowDialog()
    {
        var tStart = Time.time;

        while(true)
        {
            yield return null;
            var maxChars = Mathf.RoundToInt((Time.time - tStart) * charsPerSeconds);
            tmpText.maxVisibleCharacters = Mathf.RoundToInt((Time.time - tStart) * charsPerSeconds);

            if(Input.GetButtonDown("Action"))
            {
                if(maxChars - charsPerSeconds * 0.4f < tmpText.text.Length)
                {
                    tStart = 0f;
                }
                else
                {
                    playerController.UnblockInput(_coroutine);
                    _coroutine = null;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
