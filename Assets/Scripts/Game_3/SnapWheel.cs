using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 + Modified

public class SnapWheel : MonoBehaviour
{
    public List<Transform> snapPosition;                            //public variable lists to store the snap position and the dragable wheel
    public List<DragDropWheel> wheelObject;
    public float snapRange = 0.5f;                                  //variable type float as snap range where we will specify who close the wheel need to be to the snap position to snap on

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

    private void OnDragEnded(DragDropWheel dragdropwheel)                   //in the DragDropWheel script .....
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

        if (closestSnapPoint != null && closestDistance <= snapRange)                       //When wheel is snapped then cutscene 6 and spil 3 music will start, and the sound to spil 3 will stop. 
        {
            dragdropwheel.transform.localPosition = closestSnapPoint.localPosition;
            Debug.Log("wheel on snap");
            CutsceneManager.Instance.StartCutscene("Cut Scene 6");
            AudioManager.instance.Stop("Spil 3 Music");
            Debug.Log("Stopper Lyd til Cutscene 3 Music");
            AudioManager.instance.Play("Spil 3 Done");
        }
    }
}