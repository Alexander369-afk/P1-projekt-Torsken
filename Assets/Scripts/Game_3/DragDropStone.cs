using UnityEngine;

public class DragStone : MonoBehaviour
{
    bool dragged = false;           //boolean variable, indicates if the stone is being dragged or not (true or false)
    Vector3 offset;
    public Camera assignedCamera;   //Assign the camera in the Unity Editor

    private void OnMouseDown()      //Method that is called: when mousebutton is pressed,
                                    //this definition will happen
    {
        if (dragged)                //checks if the stone is already being dragged,  
            return;                 //if so 'return' will exit and not execute the code

        dragged = true;             //the stone is being dragged

        if (assignedCamera != null)     //if the value (assignedCamera) on the left is not equal to null
                                        //(a camera has been assigned), then execute the code below
        {
            //When pressing the mouse on the stone, this code calculates the offset/difference/distance
            //between the stone position and the mouse position. Makes it possible to drag the stone
            //from whereever it is being pressed/clicked on.
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);
           
            
            GetComponent<Rigidbody2D>().isKinematic = true;     //the dragged stone will not be influenced by physics,
                                                                //in this case not bump into other stones
                                                                //when being dragged
        }
        else                                    //if no camera is assigned (if assignedCamera is equal to null)
                                                //then show error
        {
            Debug.LogError("No camera found!");
        }
    }

    private void OnMouseUp()        //method that is called: when mousebutton is released,
                                    //this definition will happen
    {
        dragged = false;            //the stone is no longer being dragged
                                    
        GetComponent<Rigidbody2D>().isKinematic = false; //and the stone is now influenced by physics again
                                                         //in this case: when dropping the stone it will fall
                                                         //and land on the ground
    }

    private void Update()
    {
        if (dragged && assignedCamera != null)    //checks if the stone is being dragged and if a camera has been assigned,
                                                  //if so the code will be executed
        {
            //If the conditions are met the update method ensures that the stones position is updated and follows the mouse movement
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }
}