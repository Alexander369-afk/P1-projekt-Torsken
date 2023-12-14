using System.Collections;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    public GameObject rightTrigger;
    public GameObject upTrigger;
    public GameObject leftTrigger;
    public GameObject downTrigger;
    public static Sauce currentSelectedMainObject;
    private float raycastDistance = 2.70f;

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

        }

        if (this.gameObject.tag == "Gople")
        {
            ShowdDirectionGople();

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

    public void MoveObject(string direction)
    {
        // Your existing MoveObject logic...
    }

    private void ShootRightRay(float delay)
    {
        StartCoroutine(ShootRightRayCoroutine(delay));
    }

    private IEnumerator ShootRightRayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit2D hit = CastRay(Vector2.right);

        if (hit.collider != null)
        {
            rightTrigger.SetActive(false);
        }
        else
        {
            SetTriggerPosition(rightTrigger, new Vector2(transform.position.x + 2.70f, transform.position.y));
            rightTrigger.SetActive(true);
        }
    }

    private void ShootLeftRay(float delay)
    {
        StartCoroutine(ShootLeftRayCoroutine(delay));
    }

    private IEnumerator ShootLeftRayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit2D hit = CastRay(Vector2.left);

        if (hit.collider != null)
        {
            leftTrigger.SetActive(false);
        }
        else
        {
            SetTriggerPosition(leftTrigger, new Vector2(transform.position.x - 2.70f, transform.position.y));
            leftTrigger.SetActive(true);
        }
    }

    private void ShootUpRay(float delay)
    {
        StartCoroutine(ShootUpRayCoroutine(delay));
    }

    private IEnumerator ShootUpRayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit2D hit = CastRay(Vector2.up);

        if (hit.collider != null)
        {
            upTrigger.SetActive(false);
        }
        else
        {
            SetTriggerPosition(upTrigger, new Vector2(transform.position.x, transform.position.y + 2.70f));
            upTrigger.SetActive(true);
        }
    }

    private void ShootDownRay(float delay)
    {
        StartCoroutine(ShootDownRayCoroutine(delay));
    }

    private IEnumerator ShootDownRayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        RaycastHit2D hit = CastRay(Vector2.down);

        if (hit.collider != null)
        {
            downTrigger.SetActive(false);
        }
        else
        {
            SetTriggerPosition(downTrigger, new Vector2(transform.position.x, transform.position.y - 2.70f));
            downTrigger.SetActive(true);
        }
    }

    void SetTriggerPosition(GameObject trigger, Vector2 position)
    {
        trigger.transform.position = position;
    }

    private RaycastHit2D CastRay(Vector2 direction)
    {
        return Physics2D.Raycast(transform.position, direction, raycastDistance, raycastLayer);
    }

    // Any other methods or logic you might have...
}
