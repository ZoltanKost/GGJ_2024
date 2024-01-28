using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    [SerializeField] float charsPerSeconds;
    [SerializeField] PlayerController playerController;
    
    Coroutine _coroutine;
    TaskCompletionSource<bool> _source;

    public void ShowDialog(string text)
    {
        ShowDialogWithTask(text);
    }

    public Task ShowDialogWithTask(string text)
    {
        if (_coroutine != null)
        {
            _source.SetCanceled();
            playerController.UnblockInput(_coroutine);
            StopCoroutine(_coroutine);
        }

        gameObject.SetActive(true);
        tmpText.text = text;
        tmpText.maxVisibleCharacters = 0;

        _coroutine = StartCoroutine(DoShowDialog());
        _source = new TaskCompletionSource<bool>();
        playerController.BlockInput(_coroutine);
        return _source.Task;
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
                    _source.SetResult(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
