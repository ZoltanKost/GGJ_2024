using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    public AudioClip[] ricochet;
    
    public void ChangeClip(int clipValue)
    {
        AudioSource source = m_AudioSource;
        source.clip = ricochet[0];
        source.Play();
    }
}
