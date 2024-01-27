using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenueScript : MonoBehaviour
{
    [SerializeField] private GameObject languageMenue;
    public void StartGame()
    {
        languageMenue.SetActive(true); ;
    }
    public void StartGameGerman()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGameEnglisch()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
