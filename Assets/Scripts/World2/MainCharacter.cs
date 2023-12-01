using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    // Assign these in the Unity Editor
    public Canvas canvas; // Reference to the Canvas
    public GameObject buttonPrefab; // Reference to the UI Button Prefab

    // Your existing variables
    public float moveSpeed = 5f;
    public LayerMask obstacleLayer;
    public GameObject Circle;
 
    private bool isScriptActive = false;

    void Update()
    {
        if (isScriptActive && IsPathClear())
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
        float rayDistance = 160f;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, obstacleLayer);
        return hit.collider == null;
    }

    void DrawDebugRay()
    {
        Vector2 debugRayDirection = Vector2.right;
        Vector2 debugRayOrigin = transform.position;
        float debugRayDistance = 5f;
        Debug.DrawRay(debugRayOrigin, debugRayDirection * debugRayDistance, isScriptActive ? Color.green : Color.red);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ScriptMaster(other);
    }

    void ScriptMaster(Collider2D other)
    {
        if (other.CompareTag("Minispil2E"))
        {
            isScriptActive = true;
        }
        else if (other.CompareTag("Minispil3E"))
        {
            isScriptActive = false;
        }
    }
   
}


