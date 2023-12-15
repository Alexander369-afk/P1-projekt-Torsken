using UnityEngine;

public class DragStone : MonoBehaviour
{
    bool dragged = false;
    Vector3 offset;
    Camera activeCamera; // The camera to use

    private void Start()
    {
        // Assign the initial active camera (you might want to set this based on your game logic)
        activeCamera = Camera.main;

        if (activeCamera == null)
        {
            Debug.LogError("No main camera found!");
        }
    }

    private void OnMouseDown()
    {
        if (dragged)
            return;

        dragged = true;

        if (activeCamera != null)
        {
            // Get the mouse position in world space without using ScreenToWorldPoint
            Vector3 mousePosition = activeCamera.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - mousePosition;

            GetComponent<Rigidbody2D>().isKinematic = true;
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
        if (dragged && activeCamera != null)
        {
            // Get the mouse position in world space without using ScreenToWorldPoint
            Vector3 mousePosition = activeCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }
}