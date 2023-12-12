using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class audio_play : MonoBehaviour
{
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play_sound()
    {
     aud.Play();
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}

