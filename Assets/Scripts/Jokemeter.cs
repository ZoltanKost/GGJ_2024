using UnityEngine;
using UnityEngine.UI;

public class Jokemeter : MonoBehaviour
{
    [SerializeField] private float jokeMeterValue;
    [SerializeField] private float jokeMeterMaxValue;
    [SerializeField] private Image jokemeterImage;
    [SerializeField] private CalculatorHandler calculatorHandler;
    [SerializeField] private FaceEmotionsSO jokeFaces;
    

    public float Progress => (float)jokeMeterValue / jokeMeterMaxValue;

    void Awake(){
        calculatorHandler.OnJokeSubmitted += ChangeCahngeJokeMeterValue;
    }
    private void ChangeCahngeJokeMeterValue(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e)
    {
        //Activate next Line in buildt
        jokeMeterValue += e.value;
        if (jokeMeterValue > jokeMeterMaxValue)
        {
            jokeMeterValue = jokeMeterMaxValue;
        }

        jokemeterImage.sprite = jokeFaces.GetEmotion(Progress);

    }
}
