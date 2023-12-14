using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 + Modified

public class SnapWheel : MonoBehaviour
{
    public List<Transform> snapPosition;
    public List<DragDropWheel> wheelObject;
    public float snapRange = 0.5f;

    // Reference to the Path script
    public Path pathScript;

    void Awake()
    {
        foreach (DragDropWheel dragdropwheel in wheelObject)
        {
            dragdropwheel.dragEndedCallback = OnDragEnded;
            Debug.Log("on drag ended");
        }
    }

    private void OnDragEnded(DragDropWheel dragdropwheel)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPosition)
        {
            float currentDistance = Vector2.Distance(dragdropwheel.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
                Debug.Log("snappoint");
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            dragdropwheel.transform.localPosition = closestSnapPoint.localPosition;
            Debug.Log("wheel on snap");

            // Notify the Path script that the wheel is snapped
            if (pathScript != null)
            {
                pathScript.WheelSnapped();
            }
        }
    }
}