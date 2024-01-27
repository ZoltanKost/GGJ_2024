using System;
using UnityEngine;

public class CalculatorHandler : MonoBehaviour
{
    public EventHandler<OnJokeSubmittedEventArgs> OnJokeSubmitted;
    public class OnJokeSubmittedEventArgs{
        public int value;
        public AudioClip audioClip;
    }
    [SerializeField] private DropScript footer1;
    [SerializeField] private DropScript footer2;
    [SerializeField] private AudioManager audioManager;
    JokePieceSO joke1;
    JokePieceSO joke2;
    public void Calculate(){
        if(!footer1.occupied || !footer2.occupied){
            return;
        }
        joke1 = footer1.GetJokeSO();
        joke2 = footer2.GetJokeSO();
        if(!joke1.HasScore(joke2)) return;
        OnJokeSubmitted?.Invoke(this, new OnJokeSubmittedEventArgs{
            value = joke1.GetScore(joke2), 
            audioClip = joke1.GetAudio(joke2)
        });
    }
}
