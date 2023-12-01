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
    public GameObject jellyfish;
    public GameObject gople;
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

    void OnMouseDown()
    {
        Debug.Log("Mouse Down on: " + gameObject.name);

        if (gameObject == gople || gameObject == jellyfish)
        {
            ShowDirectionButtons();
            Debug.Log ("saut");
        }
    }

    void ShowDirectionButtons()
    {
        // Example: Instantiate UI buttons dynamically
        SpawnDirectionButton(Vector2.right);
        SpawnDirectionButton(Vector2.up);
        SpawnDirectionButton(Vector2.left);
        SpawnDirectionButton(Vector2.down);
    }

    void SpawnDirectionButton(Vector2 direction)
    {
        // Example: Instantiate UI button prefab and set its properties
        GameObject buttonGO = Instantiate(buttonPrefab, canvas.transform);
        Button button = buttonGO.GetComponent<Button>();
        // Add a listener to the button to handle the direction
        button.onClick.AddListener(() => MoveObject(gameObject, direction));
    }

    void MoveObject(GameObject obj, Vector2 direction)
    {
        obj.transform.position = direction;
    }
}
