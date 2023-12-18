using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAudio : MonoBehaviour
{
   public AudioManager audioManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AudioCutscene"))
        {
            AudioManager.instance.Play("Cutscene 2");
            Debug.Log("Afspiller Lyd til cutscene 2");
        }
    }
}
