using UnityEngine;

public class DragableSprite : MonoBehaviour
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
            Explode();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    void Explode()
    { 
        animator.SetTrigger("PopTrigger");
        float delay = 0.2f;
        Destroy(gameObject,delay);
    }

    
}
