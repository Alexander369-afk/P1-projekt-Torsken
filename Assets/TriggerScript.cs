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
            pathScript.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider has the tag "Spil 2"
        if (other.CompareTag("Spil 2"))
        {
            // Toggle the state of the MainCharacter script
            if (mainCharacterScript != false)
            {
                mainCharacterScript.enabled = true;
            }

            // Toggle the state of the Path script
            if (pathScript != true)
            {
                pathScript.enabled = false;
            }
        }
        // Check if the entered collider has the tag "Spil 2 slut"
        else if (other.CompareTag("Spil 2 Slut"))
        {
            // Toggle the state back to the initial state
            if (mainCharacterScript != true)
            {
                mainCharacterScript.enabled = false; // Change to the initial state if needed
            }

            if (pathScript != false)
            {
                pathScript.enabled = true; // Change to the initial state if needed
            }
        }
    }
}