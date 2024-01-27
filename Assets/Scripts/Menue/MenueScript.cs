using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueScript : MonoBehaviour
{
    [SerializeField] private GameObject languageMenue;
    [SerializeField] private LanguageScript languageScript;
    public void StartGame()
    {
        languageMenue.SetActive(true); ;
    }
    public void StartGameGerman()
    {
        languageScript.Language1 = Language.German;
        SceneManager.LoadScene(1);
    }
    public void StartGameEnglisch()
    {
        languageScript.Language1 = Language.Englisch;
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
