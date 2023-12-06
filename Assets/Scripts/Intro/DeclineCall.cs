using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;



public class DeclineCall : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
        // Time before the GameObjects are reactivated
    [SerializeField] private float _callBackTime = 3f;

    
        // Call this method to deactivate the GameObjects
    public void Call() {
        {
            FadeOut(targetTransform);
            
        }
        // Reactivate the GameObjects after the specified time
        Invoke("ReactivateGameObjects", _callBackTime);
    }
    // Call this method to reactivate the GameObjects
    void ReactivateGameObjects() 
        {
            FadeIn(targetTransform);
        }
    // Fade out the GameObjects
    void FadeOut(Transform transform)
    {
        foreach (Transform child in transform)
        {
            FadeOut(child);
        }
        CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear);
            canvasGroup.interactable = false;
        }
    }

    // Fade in the GameObjects
    void FadeIn(Transform transform) 
    {
        foreach (Transform child in transform)
        {
            FadeIn(child);
        }
        CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1f, 1f).SetEase(Ease.Linear);
            canvasGroup.interactable = true;
        }
    }
}
