using System;
using UnityEngine;

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

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Updated here

        // Check if the sound is found before attempting to play
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Updated here

        // Check if the sound is found before attempting to stop
        if (s == null)
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
            return;
        }

        s.source.Stop();
    }
}
