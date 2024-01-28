using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueScript : MonoBehaviour
{
    [SerializeField] private GameObject languageMenue;
    [SerializeField] private GameObject readMeMenue;
    [SerializeField] private LanguageScript languageScript;
    public void StartGame()
    {
        languageMenue.SetActive(true); ;
    }

    public void GetBack()
    {
        languageMenue.SetActive(false); ;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGameGerman()
    {
        languageScript.CurrentLanguage = Language.German;
        SceneManager.LoadScene(1);
    }
    public void StartGameEnglisch()
    {
        languageScript.CurrentLanguage = Language.Englisch;
        SceneManager.LoadScene(1);
    }
    public void PressReadMeButton()
    {
        readMeMenue.SetActive (true);
    }


    public void EndGame()
    {
        Application.Quit();
    }
}
