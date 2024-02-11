using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    UIManager timerScript;

    private void Awake()
    {
        timerScript = GameObject.Find("GameManager").GetComponent<UIManager>();
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);

        if (s == null) 
        {
            Debug.Log("No sound found.");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.time = musicSource.clip.length - timerScript.countdownlimit;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.soundName == name);

        if (s == null)
        {
            Debug.Log("No sound found.");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
    public void StopMusic(string name) 
    {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);
        if (s == null)
        {
            Debug.Log("No sound found to stop.");
        }
        else
        {
            musicSource.Stop();
        }
    }
}
