/* using UnityEngine;

public class KOPIHOLY : MonoBehaviour
{
    public GameObject gople;
    public GameObject jellyfish;
    public GameObject rightTrigger;
    public GameObject upTrigger;
    public GameObject leftTrigger;
    public GameObject downTrigger;

    void OnMouseDown()
    {
        Debug.Log("Mouse Down on: " + gameObject.name);

        ShowDirectionTriggers();
        Debug.Log("saut");
    }

    void ShowDirectionTriggers()
    {
        // Example: Set the triggers active at the transform of the current game object
        SetTriggerActive(rightTrigger, new Vector2(transform.position.x, transform.position.y) + Vector2.right);
        SetTriggerActive(upTrigger, new Vector2(transform.position.x, transform.position.y) + Vector2.up);
        SetTriggerActive(leftTrigger, new Vector2(transform.position.x, transform.position.y) + Vector2.left);
        SetTriggerActive(downTrigger, new Vector2(transform.position.x, transform.position.y) + Vector2.down);
    }

    void SetTriggerActive(GameObject trigger, Vector2 position)
    {
        // Example: Set the position and activate the trigger
        trigger.transform.position = position;
        trigger.SetActive(true);
        Debug.Log("saut");
    }

    void MoveObject(Vector2 direction)
    {
        transform.Translate(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check which trigger was collided with based on tags and move the GameObject accordingly
        Debug.Log("Trigger activated: " + other.gameObject.name);

        if (other.CompareTag("rightTrigger"))
        {
            MoveObject(Vector2.right);
            Debug.Log("saujht");
        }
        else if (other.CompareTag("upTrigger"))
        {
            MoveObject(Vector2.up);
            Debug.Log("saujht");
        }
        else if (other.CompareTag("leftTrigger"))
        {
            MoveObject(Vector2.left);
            Debug.Log("saujht");
        }
        else if (other.CompareTag("downTrigger"))
        {
            MoveObject(Vector2.down);
            Debug.Log("sautjh");
        }
    }
}
*/