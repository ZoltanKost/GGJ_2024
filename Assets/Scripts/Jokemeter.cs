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
        if (jokeMeterValue < 100)
        {
            jokeMeterValue += 1;
        }
        jokemeterImage.rectTransform.anchorMax = new Vector2(1f, (float)jokeMeterValue/jokeMeterMaxValue);
    }
}
