using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.Play("Telefonen Ringer");
            
        }
    }

    public void MoveToScene(int sceneID)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.Stop("Telefonen Ringer");
            audioManager.Play("Cut Scene Nul");
        }
        SceneManager.LoadScene(sceneID);
    }
}
