using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;



public class DeclineCall : MonoBehaviour
{
        // Time before the GameObjects are reactivated
    [SerializeField] private float _callBackTime = 3f;
        // Array of GameObjects that will be deactivated
    public GameObject[] declineButton;
    
        // Call this method to deactivate the GameObjects
    public void Call() {
        foreach (GameObject button in declineButton)
        {
            FadeOut(button);
            
        }
        // Reactivate the GameObjects after the specified time
        Invoke("ReactivateGameObjects",_callBackTime);
    }
    // Call this method to reactivate the GameObjects
    void ReactivateGameObjects() {
        foreach (GameObject button in declineButton)
        {
            FadeIn(button);
        }}
    // Fade out the GameObjects
    void FadeOut(GameObject obj) {
        obj.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        obj.GetComponent<CanvasGroup>().interactable = false;
    }

    // Fade in the GameObjects
    void FadeIn(GameObject obj) {
        obj.GetComponent<CanvasGroup>().DOFade(1f, 1f);
        obj.GetComponent<CanvasGroup>().interactable = true;
    }
}
