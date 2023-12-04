using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DeclineCall : MonoBehaviour

{
    [SerializeField] private float _callBackTime = 3f;
    public GameObject[] declineButton;

    public void Call() {
        foreach (GameObject button in declineButton)
        {
            button.SetActive(false);
            
        }
        Invoke("ReactivateGameObjects", _callBackTime);
    }
    void ReactivateGameObjects() {

        foreach (GameObject button in declineButton)
        {
            button.SetActive(true);
        }}
}
