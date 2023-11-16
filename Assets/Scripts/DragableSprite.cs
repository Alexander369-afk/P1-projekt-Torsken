using UnityEngine;

public class DraggableSprite : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 clickOffset;

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
        isDragging = true;
        clickOffset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}