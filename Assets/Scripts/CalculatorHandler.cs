using System;
using UnityEngine;

public class CalculatorHandler : MonoBehaviour
{
    public EventHandler<int> OnJokeSubmitted;
    [SerializeField] private DropScript footer1;
    [SerializeField] private DropScript footer2;
    [SerializeField] private AudioManager audioManager;
    JokePieceSO joke1;
    JokePieceSO joke2;
    public void Calculate(){
        if(!footer1.occupied || !footer2.occupied){
            return;
        }
        audioManager.ChangeClip(0);
        joke1 = footer1.GetJokeSO();
        joke2 = footer2.GetJokeSO();
        int num = joke1.GetScore(joke2);
        OnJokeSubmitted?.Invoke(this, num);
         Debug.Log("You gain " + num);
    }
}
