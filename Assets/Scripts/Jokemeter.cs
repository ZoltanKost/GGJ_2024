using System;
using UnityEngine;
using UnityEngine.UI;

public class Jokemeter : MonoBehaviour
{
    [SerializeField] private float jokeMeterValue;
    [SerializeField] private float jokeMeterMaxValue;
    [SerializeField] private Image jokemeterImage;

    // Update is called once per frame
    void Update()
    {
        ChangeCahngeJokeMeterValue(1);
    }

    public void ChangeCahngeJokeMeterValue(int currentJokeValue)
    {
        //Activate next Line in buildt
        //jokeMeterValue += currentJokeValue;
        if (jokeMeterValue > jokeMeterMaxValue)
        {
            jokeMeterValue = jokeMeterMaxValue;
        }
        jokemeterImage.rectTransform.anchorMax = new Vector2(1f, (float)jokeMeterValue / jokeMeterMaxValue);

    }
}
