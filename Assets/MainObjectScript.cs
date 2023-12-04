using UnityEngine;

public class MainObjectScript : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Mouse Down on: " + gameObject.name);
        ShowDirectionTriggers();
        Debug.Log("saut");
    }

    void ShowDirectionTriggers()
    {
        // Get all TriggerObjectScripts attached to this GameObject
        TriggerObjectScript[] triggerScripts = GetComponentsInChildren<TriggerObjectScript>();

        // Activate the triggers
        foreach (TriggerObjectScript triggerScript in triggerScripts)
        {
            triggerScript.ActivateTrigger();
        }
    }

    public void MoveObject(Vector2 direction)
    {
        transform.Translate(direction);
    }
}
