using System;
using UnityEngine;

// Made by the danish youtuber Brackeys https://www.youtube.com/watch?v=6OT43pvUyfY&t=637s&ab_channel=Brackeys

public class AudioManager : MonoBehaviour
{
    
    public Sound[] sounds; // Renamed the array field
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) // Updated here as well
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
      
    }

    public void Play(string name)
    {
        Debug.Log("Trying to play sound: " + name);

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
            return;
        }

        Debug.Log("Playing sound: " + s.name + " with volume: " + s.volume);
        s.source.Play();
    }


    public void Stop(string name)   // made with the help from ChatGPT
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); 

        // Check if the sound is found before attempting to stop
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
            return;
        }

        s.source.Stop();
    }
}
