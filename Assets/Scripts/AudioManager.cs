using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource VoiceSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private CalculatorHandler calculatorHandler;
    public void Awake()
    {
        calculatorHandler.OnJokeSubmitted += ChangeClip;
        Collectable.OnCollected += OnCollectedChange;
    }
    public void ChangeClip(object sender, CalculatorHandler.OnJokeSubmittedEventArgs e)
    {
        ChangeClip(e.audioClip);
    }
    void ChangeClip(AudioClip audioClip){
        VoiceSource.clip = audioClip;
        VoiceSource.Play();
    }
    void OnCollectedChange(object sender, AudioClip clip){
        VoiceSource.clip = clip;
        VoiceSource.Play();
    }
}
