using UnityEngine;
using UnityEngine.UI;

public class Jokemeter : MonoBehaviour
{
    [SerializeField] private float jokeMeterValue;
    [SerializeField] private float jokeMeterMaxValue;
    [SerializeField] private Image jokemeterImage;

    // Update is called once per frame
    public void CahngeJokeMeterValue(float currentJokeValue)
    {
        jokeMeterValue += currentJokeValue;
        if (jokeMeterValue > jokeMeterMaxValue)
        {
            jokeMeterValue = jokeMeterMaxValue;
        }
        jokemeterImage.rectTransform.anchorMax = new Vector2(1f, (float)jokeMeterValue / jokeMeterMaxValue);

    }
}
