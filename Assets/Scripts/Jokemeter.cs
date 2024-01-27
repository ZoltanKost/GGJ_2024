using UnityEngine;
using UnityEngine.UI;

public class Jokemeter : MonoBehaviour
{
    [SerializeField] private float jokeMeterValue;
    [SerializeField] private float jokeMeterMaxValue;
    [SerializeField] private Image jokemeterImage;

    private void JokeMeterValue(float currentJokeValue)
    {
        jokeMeterValue += currentJokeValue;
        float Value = (float)jokeMeterValue / jokeMeterMaxValue;
        if (Value > 1)
        {
            Value = 1;
        }

        jokemeterImage.rectTransform.anchorMax = new Vector2(jokemeterImage.rectTransform.anchorMax.x, Value);
    }
}
