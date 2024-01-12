using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s + modified

public class DragDropWheel : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------------------//
                                            //     Declarations     //
    //-----------------------------------------------------------------------------------------------------------//

    //SnapWheel script
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);
    public DragEndedDelegate dragEndedCallback;

   /* public float delay = 2;         //update 4/1-24: bliver ikke brugt alligevel. https://gamedevbeginner.com/how-to-delay-a-function-in-unity/ delay on wheel rotate after snap
    private float timer;*/
 
    Vector3 offset;                   //Three-dimensional space (x, y, z). To hold/store position data
    public Camera assignedCamera;    //Assign the camera in the Unity Editor


    bool dragged = false;           //Boolean variable, indicates if the wheel is being dragged or not (true or false)
    bool trigged = false; //kan den slettes, tjek længere nede

    //Vector3 wheelDragStartPosition;

    //public GameObject Wheel;
    public ParticleSystem Nutrition;        //
    public ParticleSystem NutritionBack;    //

    public Vector3 rotateAmount;            //


    //-----------------------------------------------------------------------------------------------------------//
                                                //     CODE     //
    //-----------------------------------------------------------------------------------------------------------//

    private void OnMouseDown()           //Method that is called: when left mousebutton is pressed,
                                         //this definition will happen
    {
        if (dragged)                     //checks if the wheel is already being dragged,
            return;                      //if so 'return' will exit and not execute the code

        dragged = true;                  //the wheel is being dragged

        if (assignedCamera != null)     //if the value (assignedCamera) on the left is not equal to null
                                        //(a camera has been assigned), then execute the code below
        {
            //When pressing the mouse on the wheel, this code calculates the offset/difference/distance
            //between the wheel and the mouse position. Makes it possible to drag the stone
            //from whereever it is being pressed/clicked on and stores it in 'offset'.
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);
           
            GetComponent<Rigidbody2D>().isKinematic = true;     //The dragged wheel will not be influenced by physics,
                                                                //like bumping into the stones or other objects with
                                                                //a rigidbody2D, when being dragged 
        }
        else                                        //If no camera is assigned (if assignedCamera is equal to null)
                                                    //then show error "No camera found!"
        {
            Debug.LogError("No camera found!");
        }
    }

    

    private void OnMouseUp()      //Method that is called: When left mouse button is released,
                                  //this definiiton will happen
    {
        dragged = false;         //The wheel is no longer being dragged

        GetComponent<Rigidbody2D>().isKinematic = false;    //And the wheel is now influenced by physics again
        

        dragEndedCallback(this);                           //
    }

    private void Update()
    {
        if (dragged && assignedCamera != null)      //Checks if the wheel is being dragged and if assignedCamera
                                                    //has been assigned if so the code will be executed
        {
            //If the conditions are met the update method ensures that the wheel position
            //is updated and follows the mouse movement
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)         //https://www.youtube.com/watch?v=jwEPKY9poa4 bruger ikke alligvel
                                                        //Bruger kun OnTriggerStay? Hvad er trigged for
    {
        Debug.Log("We have collided");

        trigged = true;                 ///
    }

    void OnTriggerStay2D(Collider2D collison)       //On wheel's collider 'is trigger' is checked.
                                                    //When colliding with WheelPosition's collider this method is called
    {
        Debug.Log("We are still colliding");

        Destroy(Nutrition, 5f);         //skal evt flyttes ned til StopTrigged?
        Destroy(NutritionBack, 5f);     //

        Invoke("StopTrigged", 6.5f);      //ChatGpt helped

    }

    void StopTrigged()
    {
        trigged = false;            ////
    }
}
