using UnityEngine;

public class DragStone : MonoBehaviour
{           // for drag and drop: code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s


    bool dragged = false;                                                                           //variable either being true or false, indicates if we are dragging or not

    Vector3 offset;                                                                                 //variable

    public Camera assignedCamera;                                                                   // Assign the camera in the Unity Editor

    private void OnMouseDown()                                                                     //invoked whenever mouse button is pressed down and when the dragging start
    {
        if (dragged)                                                                               //checks if the variable is as stated and will execute the rest of the code
            return;

        dragged = true;                                                                            //is set to true/drag is on

        if (assignedCamera != null)                                                                //!= null: not refering to a object then....
        {
                                                                                                    
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);   // Get the mouse position in world point without using ScreenToWorldPoint
                                                                                                    //offset variable used to store the distance betwwen the object, transform.position (current position) and mouse cursor position
            GetComponent<Rigidbody2D>().isKinematic = true;                                     
        }
        else
        {
            Debug.LogError("No camera found!");
        }
    }

    private void OnMouseUp()                                                                        //Whenever mouse button is released and when the dragging stops
    {
   
        dragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;

        Debug.Log("Mouse up");
    }

    private void Update()
    {
        if (dragged && assignedCamera != null)                                                      //
        {
                                                                                                   // Get the mouse position in world point without using ScreenToWorldPoint
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }
}