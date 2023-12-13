using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private Path pathScript;
    private MainCharacter mainCharacter;
    private AudioManager audioManager;
    // ... other scripts


    private void Awake()
    {
        pathScript = GetComponent<Path>();
        mainCharacter = GetComponent<MainCharacter>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Start()
    {
        AudioManager.instance.Play("Havlyden Loop");
        audioManager.Play("AV");
        FindObjectOfType<AudioManager>().Play("AV");


        if (pathScript != null)
            Debug.Log("Path script successfully retrieved.");

        else
            Debug.Log("Failed to retrieve Path script.");

        if (mainCharacter != null)
            Debug.Log("MainCharacter script successfully retrieved.");
        else
            Debug.Log("Failed to retrieve MainCharacter script.");
    }

    // Spil 2 Start
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);


                // Spil 2 Start
        if (other.CompareTag("Spil 2"))
        {
            Debug.Log("Collider with tag 'Spil 2 Start' detected.");

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

                    // Spil 2 Slut
            if (other.CompareTag("Spil 2 Slut"))
            {
                Debug.Log("Collider with tag 'Spil 2 Slut' detected.");

                if (pathScript != null)
                {
                    pathScript.enabled = true;
                    Debug.Log("PathScript enable.");
                }

                if (mainCharacter != null)
                {
                    mainCharacter.enabled = false;
                    Debug.Log("MainCharacter Disable.");
                }


            }
        }

    

   
    

        

        
    }
}
