// Code from https://stackoverflow.com/questions/55399392/destroy-gameobject-when-its-clicked-on 
using UnityEngine;

public class DragableSprite : MonoBehaviour
{
    // Class to control animation system
    private Animator animator;

    public AudioManager audioManager;

    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogWarning("AudioMangager not found in the scene.");
        }
    }

    // Start Method
    private void Start()
    {
        //Loads the Animator component from the GameObject
        animator = GetComponent<Animator>();
    }

    //Method called OnMouseDown. This is called when the user pressed the mouse or touch over a collider
    private void OnMouseDown()
    {
        //Initiate the Explode(); Method
        Explode();
    }

    //Explode method
    void Explode()
    {
        //Set the animator to PopTrigger animation
        animator.SetTrigger("PopTrigger");
        // Plays pop sound
        audioManager.Play("PopSound");
        //Sets a delay for 0.2f
        float delay = 0.2f;
        //Destroys the gameObject after delay
        Destroy(gameObject,delay);
    }
}
