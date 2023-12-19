using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Enables SceneManager in the script

public class ChangeScene : MonoBehaviour

// https://www.youtube.com/watch?v=EMo-MaKkP9s was used to understand how to change scenes within Unity using a button

{
    void Start() {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.Play("Telefonen Ringer");
        }
    }
    public void MoveToScene(int sceneID) { // This method is called by the pick up button in the intro scene. When button is clicked, the sceneID is passed to the method
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.Stop("Telefonen Ringer");
            audioManager.Play("Cut Scene Nul");
        }
        SceneManager.LoadScene(sceneID); // this loads the scene with the sceneID passed to the method, meaning it'll change scenen and start the game
    }
}
