using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //private static variable instance for audiomanager
    private static AudioManager _instance;

    //public property to retrieve audio manager instane
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is Null!");
            }
            return _instance;
        }
    }

    public AudioSource voiceOver;
    public AudioSource music;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }

    public void PlayMusic()
    {
        music.Play();
    }

}
