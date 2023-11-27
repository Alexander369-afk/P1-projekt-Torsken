using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 clickOffset;
    
    private Animator animator;

    [SerializeField] bool isPlayer;
    [SerializeField] int score = 1;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    private void Start()
    {
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
    }

    void Explode()
    { 
        scoreKeeper.ModifyScore(score);
        animator.SetTrigger("PopTrigger");
        float delay = 0.2f;
        Destroy(gameObject,delay);

    }

    
}
