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
    [Range(0f, 5f), SerializeField] private float _fadeIn = 1f;
    [Range(0f, 5f), SerializeField] private float _fadeOut = 0.5f;

    // Call this method to deactivate the GameObjects
    public void Call()
    {
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
        Renderer renderer = transform.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.DOFade(0f, _fadeOut).SetEase(Ease.Linear);
        }
    }

    // Fade in the GameObjects
    void FadeIn(Transform transform)
    {
        foreach (Transform child in transform)
        {
            FadeIn(child);
        }
        Renderer renderer = transform.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.DOFade(1f, _fadeIn).SetEase(Ease.Linear);
        }
    }
}
