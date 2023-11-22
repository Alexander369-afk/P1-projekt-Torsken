using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    // This function is called when the bubble collides with another collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider is tagged as "Square"
        if (other.CompareTag("Square"))
        {
            // Destroy the bubble GameObject
            Destroy(gameObject);
        }
    }
}