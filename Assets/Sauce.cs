using UnityEngine;

public class Sauce : MonoBehaviour
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

        if (CompareTag("rightTrigger"))
        {
            Debug.Log("Right Trigger Clicked");
            MoveObject(Vector2.right);
        }
        else if (CompareTag("upTrigger"))
        {
            Debug.Log("Up Trigger Clicked");
            MoveObject(Vector2.up);
        }
        else if (CompareTag("leftTrigger"))
        {
            Debug.Log("Left Trigger Clicked");
            MoveObject(Vector2.left);
        }
        else if (CompareTag("downTrigger"))
        {
            Debug.Log("Down Trigger Clicked");
            MoveObject(Vector2.down);
        }
        else if (CompareTag("Gople"))
        {
            Debug.Log("Gople Clicked");
            // Do something for Gople
        }
        else if (CompareTag("Waterjelly"))
        {
            Debug.Log("Waterjelly Clicked");
            ShowDirectionTriggers();
            // Do something for Waterjelly
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
        Debug.Log("saut");
    }

    void MoveObject(Vector2 direction)
    {
        transform.Translate(direction);
    }
}
