using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private CalculatorHandler calculatorHandler;
    public void Awake()
    {
        calculatorHandler.OnJokeSubmitted += ChangeClip;
    }        
    public void ChangeClip(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e)
    {
        AudioSource source = m_AudioSource;
        source.clip = e.audioClip;
        source.Play();
    }
}
