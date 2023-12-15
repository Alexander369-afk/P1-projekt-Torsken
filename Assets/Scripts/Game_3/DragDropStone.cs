using UnityEngine;

public class DragStone : MonoBehaviour
{
    bool dragged = false;
    Vector3 offset;
    public Camera assignedCamera; // Assign the camera in the Unity Editor

    private void OnMouseDown()
    {
        if (dragged)
            return;

        dragged = true;

        if (assignedCamera != null)
        {
            // Get the mouse position in world space without using ScreenToWorldPoint
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
            Debug.LogError("No camera found!");
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse up");
        dragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void Update()
    {
        if (dragged && assignedCamera != null)
        {
            // Get the mouse position in world space without using ScreenToWorldPoint
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }
}