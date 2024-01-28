using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageScript : MonoBehaviour
{
    [SerializeField] private GameObject SceneValues;
    [SerializeField] private Language currentLanguage;

    public Language CurrentLanguage
    { get => currentLanguage; set => currentLanguage = value; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

public enum Language
{
    German,
    Englisch,
}
