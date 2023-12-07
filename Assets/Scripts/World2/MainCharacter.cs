using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    // Your existing variables
    public float moveSpeed = 5f;
    public GameObject Circle;



    // Make obstacleLayer private
    private LayerMask obstacleLayer;

    void Start()
    {
        // Set obstacleLayer to the desired layer
        obstacleLayer = LayerMask.GetMask("RayHit");
    }

    void Update()
    {
        if (IsPathClear())
        {
            MoveCharacter();
        }

        // Debugging: Draw the ray
        DrawDebugRay();
    }

    void MoveCharacter()
    {
        if (IsPathClear())
        {
            Vector2 nextPosition = Vector2.MoveTowards(transform.position, Circle.transform.position, moveSpeed * Time.deltaTime);
            transform.position = nextPosition;
        }
    }

    bool IsPathClear()
    {
        Vector2 rayDirection = new Vector2(0f, 1f);
        Vector2 rayOrigin = transform.position;
        float rayDistance = 300f;

        // Use the private obstacleLayer
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, obstacleLayer);
        if (hit.collider != null)
        { 
            Debug.Log("Obstacle detected: " + hit.collider.gameObject.name);
        }
        Debug.Log("Path is clear");
        return true; 

    }

    void DrawDebugRay()
    {
        Vector2 debugRayDirection = Vector2.right;
        Vector2 debugRayOrigin = transform.position;
        float debugRayDistance = 5f;
        Debug.DrawRay(debugRayOrigin, debugRayDirection * debugRayDistance);
    }

}



