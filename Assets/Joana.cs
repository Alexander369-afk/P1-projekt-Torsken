/*using UnityEngine;

public class TriggerObjectScript : MonoBehaviour
{
    public GameObject mainObject;

    void OnMouseDown()
    {
        Debug.Log("Mouse Down on Trigger: " + gameObject.name);
        ActivateTrigger();
        Debug.Log("saut");
    }

    public void ActivateTrigger()
    {
        // Example: Set the position and activate the trigger
        transform.position = mainObject.transform.position + GetMovementDirection();
        gameObject.SetActive(true);
        Debug.Log("Trigger activated: " + gameObject.name);
    }

    Vector2 GetMovementDirection()
    {
        // Determine the movement direction based on the trigger's position
        // You can customize this based on your game logic
        if (gameObject.CompareTag("rightTrigger"))
        {
            return Vector2.right; // Adjust the direction accordingly
        }
        else if (gameObject.CompareTag("upTrigger"))
        {
            return Vector2.up;
        }
        else if (gameObject.CompareTag("leftTrigger"))
        {
            return Vector2.left;
        }
        else if (gameObject.CompareTag("downTrigger"))
        {
            return Vector2.down;
        }

        return Vector2.zero;
    }
}
*/