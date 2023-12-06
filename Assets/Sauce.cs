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
        // Logic for showing direction triggers
        ShowDirectionTriggers();
    }

    void ShowDirectionTriggers()
    {
        // Example: Set the triggers active at the transform of the current game object
        SetTriggerActive(rightTrigger, (Vector2)transform.position + Vector2.right);
        SetTriggerActive(upTrigger, (Vector2)transform.position + Vector2.up);
        SetTriggerActive(leftTrigger, (Vector2)transform.position + Vector2.left);
        SetTriggerActive(downTrigger, (Vector2)transform.position + Vector2.down);
    }

    void SetTriggerActive(GameObject trigger, Vector2 position)
    {
        // Example: Set the position and activate the trigger
        trigger.transform.position = position;
        trigger.SetActive(true);
    }

    // Method to move the main object based on trigger direction
    public void MoveObject(string direction)
    {
        Vector2 moveDirection = Vector2.zero;

        // Check the direction based on the tag
        switch (direction)
        {
            case "rightTrigger":
                moveDirection = Vector2.right;
                break;
            case "upTrigger":
                moveDirection = Vector2.up;
                break;
            case "leftTrigger":
                moveDirection = Vector2.left;
                break;
            case "downTrigger":
                moveDirection = Vector2.down;
                break;
        }

        // Move the main object
        transform.Translate(moveDirection);
    }
}