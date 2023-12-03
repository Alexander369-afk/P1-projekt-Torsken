using System.Collections;
using UnityEngine;
using Cinemachine;

public class Torsken : MonoBehaviour
{
    public float spd = 8f;
    private Rigidbody2D rb;
    public static int sceneCount = 1;
    [SerializeField] private int sceneCountCheck = 6;
    public GameObject Spil1;
    //private int erSpil1Done = 0;
    public GameObject spil1starter;
    public GameObject timelineCutscene1; //skift navn
    public GameObject CutScene2;
    public GameObject cutScene1Camera;
    public GameObject cutScene2Camera;
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public Transform initialGameObject;
    public Transform targetGameObject;
    public bool CmrFlwTorsken;

    //SPRITESHEET!!!!
    public Sprite[] spriteSheetFrames; // Array of sprites representing the frames
    public float frameDuration = 0.1f; // Duration for each frame
    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex = 0;
    private float timer = 0f;
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Activate main camera and virtual camera at the beginning
        ActivateMainCameraAndVirtualCamera();
    }

    // Coroutine for a countdown timer
    IEnumerator CountDownTimer(float timer)
    {
        Debug.Log("Timer is running");

        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        sceneCount++;
    }

    // Check if colliding with any Collider
    
    /*bool IsColliding()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale, 0);
        return collider != null;
    }*/
    void MoveTowardsTarget(float targetSpd)        //Man burde kalde hastighed og targetGameObject når man kalder funktionen
    {
        initialGameObject.position = Vector3.MoveTowards(initialGameObject.position, targetGameObject.position, targetSpd);

        // Target position is the cutScene1Camera's position
        Vector3 targetPosition = cutScene1Camera.transform.position;
        // Move the main camera
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, targetSpd * Time.deltaTime);
        // Move the virtual camera
        virtualCamera.transform.position = Vector3.MoveTowards(virtualCamera.transform.position, targetPosition, targetSpd * Time.deltaTime);
    }

    // Method to activate MainCamera and VirtualCamera
    void ActivateMainCameraAndVirtualCamera()
    {
        if (mainCamera != null)
        {
            mainCamera.enabled = true;
        }
        else
        {
            Debug.LogError("Main Camera not assigned!");
        }

        if (virtualCamera != null)
        {
            virtualCamera.enabled = true;
        }
        else
        {
            Debug.LogError("Virtual Camera not assigned!");
        }
    }

    // Method to deactivate MainCamera and VirtualCamera and activate CutScene1Camera
    void SwitchToCamera(GameObject targetCamera)
    {
        if (targetCamera != null)
        {
            // Disable the main camera
            mainCamera.enabled = false;

            // Disable CinemachineBrain to stop virtual camera control
            if (FindObjectOfType<CinemachineBrain>() != null)
            {
                FindObjectOfType<CinemachineBrain>().enabled = false;
            }

            // Enable the target camera
            targetCamera.SetActive(true);
        }
        else
        {
            // Log an error if the target camera is not assigned
            Debug.LogError("Target Camera not assigned!");
        }
    }

    void Update()
    {
        //Følg torsken
        if (CmrFlwTorsken)
        {
            mainCamera.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, mainCamera.transform.position.z);
            virtualCamera.Follow = rb.transform;
        }

        //SPRITESHEET!!!
        if (spriteSheetFrames.Length > 0)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if it's time to switch to the next frame
            if (timer >= frameDuration)
            {
                // Reset the timer
                timer = 0f;

                // Switch to the next frame
                currentFrameIndex = (currentFrameIndex + 1) % spriteSheetFrames.Length;

                // Update the sprite renderer with the new frame
                spriteRenderer.sprite = spriteSheetFrames[currentFrameIndex];
            }
        }


        // Check for sceneCount changes
        if (sceneCountCheck == sceneCount)
        {
            Debug.Log("Scene count is " + sceneCount);
            sceneCountCheck++;
        }

        // Scene progression switch
        switch (sceneCount)
        {
            case 1:
                // Move towards the bacteria and check for condition to change scene
                transform.Translate(Vector2.right * spd * Time.deltaTime);

                // Check if condition for scene change is met
                if (BakterieStop.nxtScnBak)
                {
                    Debug.Log("Box Collider 1");
                    StartCoroutine(CountDownTimer(5f));
                    sceneCount++;
                }
                break;

            /*case 2:
                // Start countdown timer and increment sceneCount
                StartCoroutine(CountDownTimer(5f));

                // Activate the TimelineCutscene1 GameObject

                sceneCount++;
                break;*/

            case 3:
                // Switch to CutScene1Camera
                StartCoroutine(CountDownTimer(6f));
                Debug.Log("snakker med bakterie");
                sceneCount++;
                break;

            case 4:
                break;

            case 5:
                StartCoroutine(CountDownTimer(6f));
                Debug.Log("Moving camera and torsken to target");
                CmrFlwTorsken = false;
                sceneCount++;
                break;

            case 6:
                MoveTowardsTarget(1f);
                break;

            case 7:
                // Start countdown timer for 25 seconds
                StartCoroutine(CountDownTimer(25f));
                if (timelineCutscene1 != null)
                {
                    timelineCutscene1.SetActive(true);
                    Debug.Log("Starter cutscene");
                }
                SwitchToCamera(cutScene1Camera);
                sceneCount++;
                break;

            case 8:
                MoveTowardsTarget(6f);
                Debug.Log("Moving towards target");
                break;

            case 9:
                // Increase speed, move towards the stone, and check for condition to change scene
                spd = 15f;
                transform.Translate(Vector2.right * spd * Time.deltaTime);

                // Check if condition for scene change is met
                if (BaktiereSpil.nxtScnSpl1)
                {
                    Debug.Log("Box Collider 2");
                    sceneCount++;
                }
                break;

            case 10:
                // Arrived at the stone + explain the game
                Debug.Log("Arrived at the stone + explain the game");

                // Start countdown timer for 4 seconds
                StartCoroutine(CountDownTimer(4f));

                // Activate the Spil1 starter
                spil1starter.SetActive(true);

                // Increment sceneCount
                sceneCount++;

                // Reactivate MainCamera and VirtualCamera after CutScene
                ActivateMainCameraAndVirtualCamera();
                CmrFlwTorsken = true;
                break;

            case 11:
                break;

            case 12:
                // The game is in progress
                Debug.Log("The game is in progress");
                sceneCount++;
                break;

            case 13:
                // Set speed, move towards VandmaendStop, and check for condition to change scene
                spd = 3;
                transform.Translate(Vector2.right * spd * Time.deltaTime);

                // Check if condition for scene change is met
                if (VandmaendStop.nxtScnVnmd)
                {
                    Debug.Log("Box Collider 3");
                    Destroy(spil1starter);

                    // Start countdown timer for 3 seconds
                    StartCoroutine(CountDownTimer(3f));

                    // Increment sceneCount
                    sceneCount++;
                }
                break;

            case 14:
                CmrFlwTorsken = false;
                break;

            case 15:
                // Start countdown timer for 3 seconds
                StartCoroutine(CountDownTimer(3f));
                if (CutScene2 != null)
                {
                    CutScene2.SetActive(true);
                    Debug.Log("Starter cutscene");
                }
                SwitchToCamera(cutScene2Camera);

                // Increment sceneCount
                sceneCount++;
                break;

            case 16:
                // Move downward with a specific speed
                spd = 3f;
                transform.Translate(new Vector2(spd * Time.deltaTime, -0.01f));
                break;

            case 17:
                // Start countdown timer for 3 seconds
                StartCoroutine(CountDownTimer(3f));

                // Increment sceneCount
                sceneCount++;
                break;

            case 18:
                break;

            case 19:
                // Move with a specific speed
                spd = 1.5f;
                transform.Translate(new Vector2(spd * Time.deltaTime, 0.03f));
                break;

            default:
                // Handle other cases or leave it empty
                break;
        }
    }

    private void FixedUpdate()
    {
        // Additional logic for FixedUpdate if needed
    }
}