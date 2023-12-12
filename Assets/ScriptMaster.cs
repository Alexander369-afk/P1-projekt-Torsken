using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private Path pathScript;
    private MainCharacter mainCharacter;
    // ... other scripts

    void Start()
    {
        // Get the scripts from the same GameObject
        pathScript = GetComponent<Path>();
        mainCharacter = GetComponent<MainCharacter>();
        // ... get other scripts similarly

        if (pathScript != null)
            Debug.Log("Path script successfully retrieved.");
        else
            Debug.Log("Failed to retrieve Path script.");

        if (mainCharacter != null)
            Debug.Log("MainCharacter script successfully retrieved.");
        else
            Debug.Log("Failed to retrieve MainCharacter script.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        if (other.CompareTag("SLUK"))
        {
            Debug.Log("Collider with tag 'SLUK' detected.");

            if (pathScript != null)
            {
                pathScript.enabled = false;
                Debug.Log("PathScript disabled.");
            }

            if (mainCharacter != null)
            {
                mainCharacter.enabled = true;
                Debug.Log("MainCharacter enabled.");
            }

            // ... other conditions and actions
        }
    }
}
