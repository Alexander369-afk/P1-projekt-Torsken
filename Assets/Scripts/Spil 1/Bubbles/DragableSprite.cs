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

/*using UnityEngine;
// Code from https://stackoverflow.com/questions/55399392/destroy-gameobject-when-its-clicked-on 

public class DragableSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 clickOffset;

    // Class to control animation system
    private Animator animator;

    [SerializeField] bool isPlayer;
    [SerializeField] int score = 1;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    // Start Method
    private void Start()
    {
        //Loads the Animator component from the GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
{
    if (isDragging)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + clickOffset;
    }
}

//Method called OnMouseDown. This is called when the user pressed the mouse or touch over a collider
private void OnMouseDown()
{
    if (!isDragging)
    {
        // Handle explosion or destruction logic here
        Explode();
    }
    else
    {
        isDragging = true;
        clickOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

private void OnMouseUp()
{
    isDragging = false;
    //Initiate the Explode(); Method
    Explode();
}

//Explode method
void Explode()
{
    scoreKeeper.ModifyScore(score);
    {
        //Set the animator to PopTrigger animation
        animator.SetTrigger("PopTrigger");
        //Sets a delay for 0.2f
        float delay = 0.2f;
        //Destroys the gameObject after delay
        Destroy(gameObject, delay);

    }


}*/
