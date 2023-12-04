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

        ShowDirectionTriggers();
        Debug.Log("saut");
    }

    void ShowDirectionTriggers()
    {
        // Example: Set the triggers active at the transform of the current game object
        SetTriggerActive(rightTrigger, (Vector2)transform.position + Vector2.right);
        SetTriggerActive(upTrigger, (Vector2)transform.position + Vector2.up);
        SetTriggerActive(leftTrigger, (Vector2)transform.position + Vector2.left);
        SetTriggerActive(downTrigger, (Vector2)transform.position + Vector2.down);
    }
}
