using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageScript : MonoBehaviour
{
    [SerializeField] private GameObject SceneValues;
    [SerializeField] private Language currentLanguage;

    public Language CurrentLanguage
    { get => currentLanguage; set => currentLanguage = value; }

    public static Language CurrentLanguageStatic
    { get => _instance.currentLanguage; set => _instance.currentLanguage = value; }

    static LanguageScript _instance;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

public enum Language
{
    German,
    Englisch,
}
