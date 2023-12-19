using System.Collections;
using System.Collections.Generic;
using DG.Tweening; // Enables DOTween in the script
using Unity.VisualScripting;
using UnityEngine;

public class DeclineCall : MonoBehaviour
{
    [SerializeField] private Transform targetTransform; // The GameObjects that will be deactivated and reactivated
    [SerializeField] private float _callBackTime = 3f; // Time before the GameObjects are reactivated
    [Range(0f, 5f), SerializeField] private float _fadeIn = 1f; // Duration of the fade in. Here we use range to set the min and max values of the float in the inspector
    [Range(0f, 5f), SerializeField] private float _fadeOut = 0.5f; // Duration of the fade out. Here we use range to set the min and max values of the float in the inspector
    private float _alphaZero = 0f; // Float to set the alpha value of the material, used in the FadeOut method so the GameObjects turn invisible
    private float _alphaOne = 1f; // Float to set the alpha value of the material, used in the FadeIn method so the GameObjects turn visible

    // https://www.youtube.com/watch?v=zFsJvMitly0 & https://www.youtube.com/watch?v=7PZGWNdH-t4was used to understand how use fadein and fadeout.
    // ChatGPT was utalized to help us apply the script to our specific needs.
    // Understanding the renderer.material was the main issue as the GameObjects are not a UI element within a canvasGroup
    // The asset DOTween was used to make the fade in and fade out smoother


    // Call this method to deactivate the GameObjects
    public void Call()
    {
        {
           FadeOut(targetTransform); // When Call() is called, the GameObjects will fade out
        }
       Invoke("ReactivateGameObjects", _callBackTime); // Using invoke to reactivate the GameObjects after the specified time (_callBackTime)
    }
    void ReactivateGameObjects() // this method is called by Invoke
    {
        FadeIn(targetTransform); // When ReactivateGameObjects() is called, the GameObjects will fade in
    }
    void FadeOut(Transform transform) // This is a recursive method that loops through all child GameObjects
    {
        foreach (Transform child in transform) // Loop through all child GameObjects
        {
            FadeOut(child);
        }
        Renderer renderer = transform.GetComponent<Renderer>(); // Get the Renderer component of the GameObject

        if (renderer != null) // If the GameObject has a Renderer component, set the alpha value of the material
        {
            renderer.material.DOFade(_alphaZero, _fadeOut).SetEase(Ease.Linear); // Fade out the material from the current alpha value to 0
        }
    }
    void FadeIn(Transform transform) // Fade in the GameObjects
    {
        foreach (Transform child in transform)
        {
            FadeIn(child);
        }
        Renderer renderer = transform.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.DOFade(_alphaOne, _fadeIn).SetEase(Ease.Linear); // Fade in the material from the current alpha value to 1
        }
    }
}
