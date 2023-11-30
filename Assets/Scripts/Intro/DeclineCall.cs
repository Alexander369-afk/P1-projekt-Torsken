using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclineCall : MonoBehaviour
{
    public GameObject[] declineButton;
      void Start()
    {
        declineButton = GameObject.FindGameObjectsWithTag("IntroTag");
    }
    public void Call() 
    {
        foreach (GameObject button in declineButton)
        {
            button.SetActive(false);
        }
        
    }
}
