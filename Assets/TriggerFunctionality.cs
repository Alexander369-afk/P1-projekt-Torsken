using UnityEngine;

public class TriggerFunctionality : MonoBehaviour
{
    void OnMouseDown()
    {
        // Get the tag of the clicked trigger
        string triggerTag = gameObject.tag;

        // Move the main object based on the trigger's tag
        Sauce sauceScript = FindObjectOfType<Sauce>();
        Sauce.currentSelectedMainObject.MoveObject(triggerTag);
        
    }
}
