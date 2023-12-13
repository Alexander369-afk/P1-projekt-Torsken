using System.Collections;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    public GameObject rightTrigger;
    public GameObject upTrigger;
    public GameObject leftTrigger;
    public GameObject downTrigger;
    public static Sauce currentSelectedMainObject;
    private float raycastDistance = 1.5f;
    private LayerMask raycastLayer;
    private int originalLayer;
    private AudioManager audioManager;


    void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (audioManager == null)
        {

            Debug.LogWarning("AudioMangager not found in the scene.");
        }
    }
    void Start()
    {
        raycastLayer = LayerMask.GetMask("RayHit");
        originalLayer = gameObject.layer;
    }

    void Update()
    {
        if (currentSelectedMainObject != null)
        {
            if (currentSelectedMainObject.gameObject.CompareTag("Waterjelly"))
            {
                currentSelectedMainObject.ShowDirectionWaterjelly();
            }

            if (currentSelectedMainObject.gameObject.CompareTag("Gople"))
            {
                currentSelectedMainObject.ShowdDirectionGople();
            }
            if (currentSelectedMainObject != this)
            {
                // Restore the original layer.
                gameObject.layer = originalLayer;
            }
        }
    }

    void OnMouseDown()
    {
        currentSelectedMainObject = this;

        if (this.gameObject.tag == "Waterjelly")
        {
            ShowDirectionWaterjelly();
            audioManager.Play("Vandmand");
        }

        if (this.gameObject.tag == "Gople")
        {
            ShowdDirectionGople();
            audioManager.Play("Brandmand");
        }
    }

    void ShowDirectionWaterjelly()
    {
        ShootDownRay(0.1f);
        ShootUpRay(0.1f);
        ShootLeftRay(0.1f);
        ShootRightRay(0.1f);

    }

    void ShowdDirectionGople()
    {
        ShootDownRay(0.1f);
        ShootUpRay(0.1f);
        leftTrigger.SetActive(false);
        rightTrigger.SetActive(false);
    }

    // Method to move the main object based on trigger direction
    public void MoveObject(string direction)
    {
        Vector2 moveDirection = Vector2.zero;

        switch (direction)
        {
            case "rightTrigger":
                moveDirection = new Vector2(1.35f, 0f);
                break;
            case "upTrigger":
                moveDirection = new Vector2(0f, 1.35f);
                break;
            case "leftTrigger":
                moveDirection = new Vector2(-1.35f, 0f);
                break;
            case "downTrigger":
                moveDirection = new Vector2(0f, -1.35f);
                break;
        }

        transform.Translate(moveDirection);
    }

    private void ShootRightRay(float delay)
    {
        // Temporary layer for raycasting.
        int temporaryLayer = 1;
        gameObject.layer = temporaryLayer;

        StartCoroutine(ShootRightRayCoroutine(delay));
    }

    private IEnumerator ShootRightRayCoroutine(float delay)
    {
        // Delay without changing the layer.
        yield return new WaitForSeconds(delay);

        // Cast the ray after the delay.
        RaycastHit2D hit = CastRay(Vector2.right);

        if (hit.collider != null)
        {
            Debug.Log("Hit object in the right direction: " + hit.collider.gameObject.name);
            rightTrigger.SetActive(false);
        }
        else
        {
            SetTriggerPosition(rightTrigger, (Vector2)transform.position + Vector2.right);
            rightTrigger.SetActive(true);
        }

        Debug.DrawRay(transform.position, Vector2.right * raycastDistance, Color.yellow);
    }

    private void ShootLeftRay(float delay)
    {
        // Temporary layer for raycasting.
        int temporaryLayer = 0;
        gameObject.layer = temporaryLayer;

        StartCoroutine(ShootLeftRayCoroutine(delay));
    }

    private IEnumerator ShootLeftRayCoroutine(float delay)
    {
        // Delay without changing the layer.
        yield return new WaitForSeconds(delay);

        // Cast the ray after the delay.
        RaycastHit2D hit = CastRay(Vector2.left);

        if (hit.collider != null)
        {
            Debug.Log("Hit object in the left direction: " + hit.collider.gameObject.name);
            leftTrigger.SetActive(false);
        }
        else
        {
            leftTrigger.SetActive(true);
            SetTriggerPosition(leftTrigger, (Vector2)transform.position + Vector2.left);
        }

        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, Color.green);
    }

    private void ShootUpRay(float delay)
    {
        // Temporary layer for raycasting.
        int temporaryLayer = 0;
        gameObject.layer = temporaryLayer;

        StartCoroutine(ShootUpRayCoroutine(delay));
    }

    private IEnumerator ShootUpRayCoroutine(float delay)
    {
        // Delay without changing the layer.
        yield return new WaitForSeconds(delay);

        // Cast the ray after the delay.
        RaycastHit2D hit = CastRay(Vector2.up);

        if (hit.collider != null)
        {
            Debug.Log("Hit object in the up direction: " + hit.collider.gameObject.name);
            upTrigger.SetActive(false);
        }
        else
        {
            upTrigger.SetActive(true);
            SetTriggerPosition(upTrigger, (Vector2)transform.position + Vector2.up);
        }

        Debug.DrawRay(transform.position, Vector2.up * raycastDistance, Color.red);
    }

    private void ShootDownRay(float delay)
    {
        // Temporary layer for raycasting.
        int temporaryLayer = 0;
        gameObject.layer = temporaryLayer;

        StartCoroutine(ShootDownRayCoroutine(delay));
    }

    private IEnumerator ShootDownRayCoroutine(float delay)
    {
        // Delay without changing the layer.
        yield return new WaitForSeconds(delay);

        // Cast the ray after the delay.
        RaycastHit2D hit = CastRay(Vector2.down);

        // Check if the main object is still the current selected main object.
        if (currentSelectedMainObject == this)
        {
            // Main object is still selected, handle the raycast results.
            if (hit.collider != null)
            {
                Debug.Log("Hit object in the down direction: " + hit.collider.gameObject.name);
                downTrigger.SetActive(false);
            }
            else
            {
                downTrigger.SetActive(true);
                SetTriggerPosition(downTrigger, (Vector2)transform.position + Vector2.down);
            }
        }

        // Debug draw for visualization.
        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.blue);
    }

    void SetTriggerPosition(GameObject trigger, Vector2 position)
    {
        trigger.transform.position = position;
    }

    private RaycastHit2D CastRay(Vector2 direction)
    {
        return Physics2D.Raycast(transform.position, direction, raycastDistance, raycastLayer);
    }
}
