using UnityEngine;

public class TriggerScript : MonoBehaviour
 

{
    public GameObject rightTrigger;
    public GameObject upTrigger;
    public GameObject leftTrigger;
    public GameObject downTrigger;

    void OnMouseDown()
    
    {
        // Retrieve the main object's Holymoley script
        Holymoley holymoleyScript = transform.parent.GetComponent<Holymoley>();

        if (holymoleyScript != null)
        {
            // Determine the direction based on the trigger's tag
            Vector2 direction = Vector2.zero;

            if (CompareTag("rightTrigger"))
            {
                direction = Vector2.right;
            }
            else if (CompareTag("upTrigger"))
            {
                direction = Vector2.up;
            }
            else if (CompareTag("leftTrigger"))
            {
                direction = Vector2.left;
            }
            else if (CompareTag("downTrigger"))
            {
                direction = Vector2.down;
            }

            // Move the main object in the determined direction
            holymoleyScript.MoveObject(direction);
        }
    }
}
