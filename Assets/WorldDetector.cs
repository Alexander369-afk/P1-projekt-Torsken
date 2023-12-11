using UnityEngine;

public class WorldDetector : MonoBehaviour
{
    public string[] allowedTags = { "Gople", "Waterjelly", "Obstacle" }; // Tags of objects that can trigger collision

    // Method to check collision and return the result
    public bool CheckCollision(Collider2D collider)
    {
        // Create an array to store the colliders
        Collider2D[] colliders = new Collider2D[10];

        // Get all colliders overlapping with the provided collider
        int colliderCount = Physics2D.OverlapCollider(collider, new ContactFilter2D(), colliders);

        // Check if any of the colliders have an allowed tag
        for (int i = 0; i < colliderCount; i++)
        {
            if (IsTagAllowed(colliders[i].gameObject.tag))
            {
                Debug.Log("Collision with an allowed tag!");
                return true; // Collision with allowed tag detected
            }
        }

        return false; // No collision with allowed tag detected
    }

    bool IsTagAllowed(string tag)
    {
        // Check if the tag is in the allowedTags array
        foreach (string allowedTag in allowedTags)
        {
            if (tag == allowedTag)
            {
                return true;
            }
        }

        return false;
    }
}
