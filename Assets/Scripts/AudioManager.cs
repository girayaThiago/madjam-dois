using System;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds){
           
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.clip = s.clip;
            s.source.pitch = 1;
            s.source.loop = s.loop;
        }

    }

    private void Start()
    {

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Error sound: " + name + " was not found!");
        } else
        {
            if (!s.source.isPlaying)
            {
                s.source.Play();
            }
        }
    }

    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Error sound: " + name + " was not found!");
        }
        else
        {
            s.source.PlayOneShot(s.clip);
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (s.source.isPlaying)
            {
                s.source.Stop();
            }
        }
    }
}
