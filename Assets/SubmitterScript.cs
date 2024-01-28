using TMPro;
using UnityEngine;

public class SubmitterScript : MonoBehaviour
{
    [SerializeField] private CalculatorHandler calculatorHandler;
    [SerializeField] private TMP_Text text;

    public bool IsComplete => num >= 5;
    public int NumJokesCommited => num;
    
    int num = 0;


    void Awake(){
        text.text = num.ToString();
        calculatorHandler.OnJokeSubmitted += OnJokeSubmitted; 
    }
    void OnJokeSubmitted(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e){
        if(num >= 5 || !e.didScore) return;
        num++;
        text.text = num.ToString();
    }
}
