using TMPro;
using UnityEngine;

public class SubmitterScript : MonoBehaviour
{
    [SerializeField] private CalculatorHandler calculatorHandler;
    [SerializeField] private TMP_Text text;
    int num = 0;
    void Awake(){
        text.text = num.ToString();
        calculatorHandler.OnJokeSubmitted += OnJokeSubmitted; 
    }
    void OnJokeSubmitted(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e){
        if(num >= 5) return;
        num++;
        text.text = num.ToString();
    }
}
