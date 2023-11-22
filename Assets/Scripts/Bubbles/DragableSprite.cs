using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 clickOffset;

    private Animator animator;

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

    private void Explode()
    {
        animator.SetTrigger("PopTrigger");

        float delay = 1.0f;

        Destroy(gameObject, delay);

    }
}
