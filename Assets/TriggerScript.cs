using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private MainCharacter mainCharacterScript;
    private Path pathScript;

    private void Start()
    {
        // Cache references to the MainCharacter and PathScript components
        mainCharacterScript = GetComponent<MainCharacter>();
        pathScript = GetComponent<Path>();

        // Ensure both scripts are initially disabled
        if (mainCharacterScript != null)
        {
            mainCharacterScript.enabled = false;
        }

        if (pathScript != null)
        {
            pathScript.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider has the tag "Spil 2"
        if (other.CompareTag("Spil 2"))
        {
            // Toggle the state of the MainCharacter script
            if (mainCharacterScript != null)
            {
                mainCharacterScript.enabled = !mainCharacterScript.enabled;
            }

            // Toggle the state of the Path script
            if (pathScript != null)
            {
                pathScript.enabled = !pathScript.enabled;
            }
        }
        // Check if the entered collider has the tag "Spil 2 slut"
        else if (other.CompareTag("Spil 2 slut"))
        {
            // Toggle the state back to the initial state
            if (mainCharacterScript != null)
            {
                mainCharacterScript.enabled = false; // Change to the initial state if needed
            }

            if (pathScript != null)
            {
                pathScript.enabled = false; // Change to the initial state if needed
            }
        }
    }
}