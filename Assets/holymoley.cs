using UnityEngine;

public class Holymoley : MonoBehaviour
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

        if (gameObject == gople || gameObject == jellyfish)
        {
            ShowDirectionTriggers();
            Debug.Log("saut");
        }
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
    }

    void MoveObject(Vector2 direction)
    {
        transform.Translate(direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == rightTrigger)
        {
            MoveObject(Vector2.right);
        }
        else if (other.gameObject == upTrigger)
        {
            MoveObject(Vector2.up);
        }
        else if (other.gameObject == leftTrigger)
        {
            MoveObject(Vector2.left);
        }
        else if (other.gameObject == downTrigger)
        {
            MoveObject(Vector2.down);
        }
    }
}
