using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DeclineCall : MonoBehaviour
{
    public GameObject[] declineButton;
      void Start()
    {
        // declineButton = GameObject.FindGameObjectsWithTag("IntroTag");
    }
    public void Call() {
        foreach (GameObject button in declineButton)
        {
            button.SetActive(false);
            
        }
        Invoke("ReactivateGameObjects",3f);
    }
    void ReactivateGameObjects() {

        foreach (GameObject button in declineButton)
        {
            button.SetActive(true);
        }}
}
