using UnityEngine;

// Code from YouTube https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s + modified

public class DragStone : MonoBehaviour      //Ingen ide om hvorfor class navn er anderledes?? Ingen error i Unity. og hvorfor mangler der nogle namespace
{
    //-----------------------------------------------------------------------------------------------//
                                     //  Declarations    //
    //-----------------------------------------------------------------------------------------------//

    //Boolean variable, indicates if the stone is being dragged or not (true or false)
    bool dragged = false;

    //Three-dimentional space (x, y, z). To hold/store position data
    Vector3 offset;

    //Assign the camera in the Unity Editor
    public Camera assignedCamera;



    //-----------------------------------------------------------------------------------------------//
                                         //     CODE    //
    //-----------------------------------------------------------------------------------------------//
        //The point of the code: Stones placed in the game needs to be clicked/pressed on, able to be dragged around
        //and dropped. When dragged the stones should not collide with other Colliders, as the user needs to find
        //a wheel hidden behind one of the stones. 


    //Method/function that is called: when left mousebutton is pressed,this code will be executed
    private void OnMouseDown()                                    
    {
        //Checks if the stone is already being dragged (true), if so the 'return' will exit the method/function
        //and not execute the rest of the code inside the method/function
        if (dragged)                 
            return;                 

        //The stone is being dragged
        dragged = true;


        //if assignedCamera on the left is not equal to null (a camera has been assigned), then execute the code below
        if (assignedCamera != null)     
        {
            //When pressing the mouse on the stone, this code calculates the offset/difference/distance
            //between the stone position and the mouse position. Makes it possible to drag the stone
            //from whereever it is being pressed/clicked on
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);

            //The dragged stone will not be influenced by physics,in this case not bump into other stones
            //when being dragged
            GetComponent<Rigidbody2D>().isKinematic = true;                                                                
        }

        //If no camera is assigned (if assignedCamera is equal to null) then show error
        else
        {
            Debug.LogError("No camera found!");
        }
    }

    //Method/function that is called: when left mousebutton is released, this code will be executed
    private void OnMouseUp()        
    {
        //the stone is no longer being dragged
        dragged = false;

        //The stone is now influenced by physics again in this case: when dropping the stone it will fall
        //and land on the ground (it hits an EdgeCollider)
        GetComponent<Rigidbody2D>().isKinematic = false; 
    }

    private void Update()
    {
        //checks if the stone is being dragged and if a camera has been assigned, if so the code will be executed
        if (dragged && assignedCamera != null)    
        {
            //If the conditions are met the update method/function ensures that the stones position is updated and follows the mouse movement
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
        //Could have put an 'else' statement here, if 'if' statement should fail
    }
}