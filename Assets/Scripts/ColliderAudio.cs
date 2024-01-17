using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColliderAudio : MonoBehaviour
{
    public AudioManager audioManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Start Statements
        if (other.CompareTag("AudioCutscene"))
        {
            AudioManager.instance.Play("Cutscene 2");
            Debug.Log("Afspiller Lyd til cutscene 2");
            // Deactivate the collider on the other GameObject
            other.enabled = false;
        }

        if (other.CompareTag("IntroMusic"))
        {
            AudioManager.instance.Play("IntroMusic");
            Debug.Log("Afspiller Lyd til IntroMusic");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 1 Forklaring"))
        {
            AudioManager.instance.Play("Spil 1 Forklaring");
            Debug.Log("Afspiller Lyd til Spil 1 Forklaring");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 1 Music"))
        {
            AudioManager.instance.Play("Spil 1 Music");
            Debug.Log("Afspiller Lyd til Spil 1 Music");
            other.enabled = false;
        }

        if (other.CompareTag("Cutscene 2 Dialog"))
        {
            AudioManager.instance.Play("Cutscene 2 Dialog");
            Debug.Log("Afspiller Lyd til Cutscene 2");
            other.enabled = false;
        }

        if (other.CompareTag("Cutscene 2 Music"))
        {
            AudioManager.instance.Play("Cutscene 2 Music");
            Debug.Log("Afspiller Lyd til Cutscene 2 Music + Forklaring");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 2 Music"))
        {
            AudioManager.instance.Play("Spil 2 Music");
            Debug.Log("Afspiller Lyd til Spil 2");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 2 Vinder"))
        {
            AudioManager.instance.Play("Spil 2 Vinder");
            Debug.Log("Afspiller Lyd til Spil 2 Vinder");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 3 Music"))
        {
            AudioManager.instance.Play("Spil 3 Music");
            Debug.Log("Afspiller Lyd til Spil 3 Music");
            other.enabled = false;
        }

        //Stop Statements
        if (other.CompareTag("Intro Music Stop"))
        {
            AudioManager.instance.Stop("IntroMusic");
            Debug.Log("Stopper Lyd til Intro Music");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 1 Music Stop"))
        {
            AudioManager.instance.Stop("Spil 1 Music");
            Debug.Log("Stopper Lyd til Spil 1 Music");
            other.enabled = false;
        }

        if (other.CompareTag("Cutscene 2 Music Stop"))
        {
            AudioManager.instance.Stop("Cutscene 2 Music");
            Debug.Log("Stopper Lyd til Cutscene 2 Music");
            other.enabled = false;
        }

        if (other.CompareTag("Spil 2 Music Stop"))
        {
            AudioManager.instance.Stop("Spil 2 Music");
            Debug.Log("Stopper Lyd til Spil 2");
            other.enabled = false;
        }
    }
}