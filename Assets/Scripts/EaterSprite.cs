using UnityEngine;

public class EaterSpriteScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            Destroy(other.gameObject); // Destroy the draggable sprite when it enters the eater sprite
            Debug.Log("Drank the draggable sprite!");
        }
    }
}