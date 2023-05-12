using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public sounds[] musicsounds;
    public AudioSource musicSource;


    public string MusicName;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playMusic(MusicName);
    }
    public void playMusic(string name)
    {
        sounds s = Array.Find(musicsounds, x => x.name == name); 
        if(s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void togglemusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void musicvolume(float volume)
    {
        musicSource.volume = volume;
    }
}
