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
            s.AudioSource =  gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.clip;

            s.AudioSource.volume = s.volume;
            s.AudioSource.pitch = s.pitch;
            s.AudioSource.loop = s.loop; 

        }
    }
    void Start()
    {
        // skriv Play("") navn for at spille i start. 
        
    }

    // Update is called once per frame
    public void Play (string name)
    {
        SoundPlaceHolder s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
           
        s.AudioSource.Play();
        
    }

}
  

