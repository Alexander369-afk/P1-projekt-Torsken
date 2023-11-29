using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask obstacleLayer;

    private bool isScriptActive = false;

    void Update()
    {
        if (isScriptActive && IsPathClear())
        {
            // Move your character based on waypoints or any other movement logic
            MoveCharacter();
        }

        // Debugging: Draw the ray
        DrawDebugRay();
    }

    void MoveCharacter()
    {
        // Implement your character's movement logic here
        // For example, you can use a system of waypoints, input, or other methods
    }

    bool IsPathClear()
    {
        // Input your own variables for the ray
        Vector2 rayDirection = Vector2.right; // Replace with your desired direction
        Vector2 rayOrigin = transform.position; // Replace with your desired origin
        float rayDistance = 5f; // Replace with your desired distance

        // Check if the path is clear using Physics2D.Raycast for 2D games
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, obstacleLayer);
        if (hit.collider != null)
        {
            // Path is obstructed
            return false;
        }

        // Path is clear
        return true;
    }

    void DrawDebugRay()
    {
        // Input your own variables for the debug ray
        Vector2 debugRayDirection = Vector2.right; // Replace with your desired direction
        Vector2 debugRayOrigin = transform.position; // Replace with your desired origin
        float debugRayDistance = 5f; // Replace with your desired distance

        // Draw the debug ray for visualization
        Debug.DrawRay(debugRayOrigin, debugRayDirection * debugRayDistance, isScriptActive ? Color.green : Color.red);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Renamed from HandleTriggerEnter to ScriptMaster
        ScriptMaster(other);
    }

    void ScriptMaster(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isScriptActive = true;
        }
        else if (other.CompareTag("Minispil3"))
        {
            isScriptActive = false;
        }
    }
}
