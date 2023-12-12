using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundPlaceHolder[] sounds;

    void Awake()
    {
        foreach (SoundPlaceHolder s in sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.clip;
            s.AudioSource.volume = s.volume;
            s.AudioSource.pitch = s.pitch;
            s.AudioSource.loop = s.loop; 
        }
    }

    public void Play(string name)
    {
        SoundPlaceHolder s = Array.Find(sounds, sound => sound.name == name);

        // Check if the sound is found before attempting to play
        if (s != null && s.AudioSource != null)
        {
            s.AudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound with name " + name + " not found.");
        }
    }
}