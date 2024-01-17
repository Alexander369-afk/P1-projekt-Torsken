using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// Code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s + modififed

public class DragDropWheel : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------//
    //  Declarations    //
    //-----------------------------------------------------------------------------------------------//

    //Delegate is a reference type to hold a reference to a method/funtion. We make a reference to
    //the OnMouseUp method/function as we need to use the information in SnapWheel script
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);
    //Varable of the delegate. Callback 
    public DragEndedDelegate dragEndedCallback;


    /* public float delay = 2;         //update 4/1-24: bliver ikke brugt alligevel. https://gamedevbeginner.com/how-to-delay-a-function-in-unity/ delay on wheel rotate after snap
     private float timer;*/

    //public GameObject Wheel;

    //Three-dimensional space (x, y, z). To hold/store position data
    Vector3 offset;

    //Assign the camera in the Unity Editor
    public Camera assignedCamera;

    //Variable either being true or false
    bool dragged = false;           
    bool trigged = false; //Tror denne skal slettes, så kan OnTrigger også slettes


    //To destroy them when the wheel has snapped to the pipe. In the Unity Editor, the ParticleSystem components can be assigned
    public ParticleSystem Nutrition;
    public ParticleSystem NutritionBack;

    //Wheel rotating when snapped. In Unity Editor the amount of rotate can be changed
    public Vector3 rotateAmount;



    //-----------------------------------------------------------------------------------------------//
                                             //     CODE    //
    //-----------------------------------------------------------------------------------------------//
    //The point of the code: Wheel needs to be dragged to the pipe and droppede. When dropped it should snap
    //onto the pipe, rotate for a few seconds to make it look like it is closing the steam of nutritions, 
    //and then the nutritions will turn off/be destroyed

    //Method/function that is called: when left mousebutton is pressed, this code will be executed
    private void OnMouseDown()
    {
        //Checks if the wheel is already being dragged (true), if so the 'return' will exit the method/function
        //and not execute the rest of the code inside the method/function
        if (dragged)
            return;

        //The wheel is being dragged
        dragged = true;

        //if assignedCamera on the left is not equal to null (a camera has been assigned), then execute the code below
        if (assignedCamera != null)
        {
            //When pressing the mouse on the wheel, this code calculates the offset/difference/distance
            //between the wheel position and the mouse position. Makes it possible to drag the wheel
            //from whereever it is being pressed/clicked on
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);

            //The dragged wheel will not be influenced by physics
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
        //Wheel is no longer being dragged
        dragged = false;

        //The wheel is now influenced by physics again
        GetComponent<Rigidbody2D>().isKinematic = false;
        
        //When the user lets go of the wheel and drags end, we want to call the callback
        dragEndedCallback(this);
    }

    private void Update()
    {
        //checks if the wheel is being dragged and if a camera has been assigned, if so the code will be executed
        if (dragged && assignedCamera != null)
        {
            //If the conditions are met the update method/function ensures that the wheels position is updated and follows the mouse movement
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }

        //Could have put an 'else' statement here, if 'if' statement should fail
    }


    void OnTriggerEnter2D(Collider2D collision) 
    {

        trigged = true;
    }

  void OnTriggerStay2D(Collider2D collison)
    {
        //When wheel has snapped, nutritions will be destroyed
        Destroy(Nutrition, 5f);
        Destroy(NutritionBack, 5f);

        Invoke("StopTrigged", 6.5f);      //ChatGpt helped

    }

    void StopTrigged()
    {
        trigged = false;
    }
}
