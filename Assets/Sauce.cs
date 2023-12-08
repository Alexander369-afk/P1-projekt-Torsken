using UnityEngine;

public class Sauce : MonoBehaviour
{

    public GameObject rightTrigger;
    public GameObject upTrigger;
    public GameObject leftTrigger;
    public GameObject downTrigger;
    public static Sauce currentSelectedMainObject;

    void Update()
    {
        if (currentSelectedMainObject != null)
        {
            // Logic for showing direction triggers for the current selected main object
            if (currentSelectedMainObject.gameObject.CompareTag("Waterjelly"))
            {
                currentSelectedMainObject.ShowDirectionTriggers();
            }

            if (currentSelectedMainObject.gameObject.CompareTag("Gople"))
            {
                currentSelectedMainObject.ShowdDirectionGople();
            }
        }

    }
    
    void OnMouseDown()
    {
        currentSelectedMainObject = this;

      

        if (this.gameObject.tag == "Waterjelly") // https://www.youtube.com/watch?v=LoeFzKTTZU4&ab_channel=ChargerGames
        {
            ShowDirectionTriggers(); 
        }

        // Logic for showing direction triggers
        if (this.gameObject.tag == "Gople") // https://www.youtube.com/watch?v=LoeFzKTTZU4&ab_channel=ChargerGames
        {
            ShowdDirectionGople();
        }

       

    }

    void ShowDirectionTriggers()
    {
        // Example: Set the triggers active at the transform of the current game object
        SetTriggerActive(rightTrigger, (Vector2)transform.position + Vector2.right);
        SetTriggerActive(upTrigger, (Vector2)transform.position + Vector2.up);
        SetTriggerActive(leftTrigger, (Vector2)transform.position + Vector2.left);
        SetTriggerActive(downTrigger, (Vector2)transform.position + Vector2.down);
    }

    void ShowdDirectionGople()
    {
        SetTriggerActive(upTrigger, (Vector2)transform.position + Vector2.up);
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

        // Move the main object
        transform.Translate(moveDirection);
    }
     

}