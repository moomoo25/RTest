using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager singleton;
    public AudioSource audioSource;
    public AudioClip audioPaperClip;
    public AudioClip audioClip;
    public AudioClip audioWrongClip;
    public AudioClip audioCorrectClip;
    private void Awake()
    {
        singleton = this;
    }
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void PlayPaperSound()
    {
        audioSource.PlayOneShot(audioPaperClip);
    }
    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(audioWrongClip);
    }
    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(audioCorrectClip);
    }
}
