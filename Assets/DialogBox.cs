using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField] TMP_Text tmpText;
    [SerializeField] float charsPerSeconds;
    
    Coroutine _coroutine;

    public void ShowDialog(string text)
    {
        if(_coroutine!=null)
        {
            StopCoroutine(_coroutine);
        }

        gameObject.SetActive(true);
        tmpText.text = text;
        tmpText.maxVisibleCharacters = 0;

        _coroutine = StartCoroutine(DoShowDialog());
    }

    IEnumerator DoShowDialog()
    {
        var tStart = Time.time;

        while(true)
        {
            var maxChars = Mathf.RoundToInt((Time.time - tStart) * charsPerSeconds);
            tmpText.maxVisibleCharacters = Mathf.RoundToInt((Time.time - tStart) * charsPerSeconds);

            if(Input.GetButtonDown("Action"))
            {
                if(maxChars - charsPerSeconds * 0.4f < tmpText.maxVisibleCharacters )
                {
                    tStart = 0f;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
