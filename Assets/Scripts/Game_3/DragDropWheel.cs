using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragDropWheel : MonoBehaviour
{
            // for snap drag and drop: code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s
   
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);

    public DragEndedDelegate dragEndedCallback;

    public float delay = 2;                                                                           //https://gamedevbeginner.com/how-to-delay-a-function-in-unity/ delay on wheel rotate after snap

    bool dragged = false;                                                                             //variable either being true or false, indicates if we are dragging or not
    bool trigged = false;

    Vector3 offset;                                                                                   //variable 
    public Camera assignedCamera;                                                                     // Assign the camera in the Unity Editor



    public ParticleSystem Nutrition;
    public ParticleSystem NutritionBack;

    public Vector3 rotateAmount;

    private void OnMouseDown()                                                                      //invoked whenever mouse button is pressed down and when the dragging start
    {
        if (dragged)                                                                                //checks the value of the variable 'dragged'. If the variable is true the rest of the code will be executed. if not it will ignore. this is to prevent unexpected behavior or conflict to happen.
            return;

        dragged = true;                                                                             //is set to true/drag is on

        if (assignedCamera != null)                                                                 //!= null: not refering to a object then....
        {
                                                                                                    
            offset = transform.position - assignedCamera.ScreenToWorldPoint(Input.mousePosition);   //Get the mouse position in world point without using ScreenToWorldPoint
                                                                                                    //offset variable used to store the distance betwwen the object, transform.position (current position) and mouse cursor position
            GetComponent<Rigidbody2D>().isKinematic = true;                                         //GetComp. a method to access the Rigidbody2D component on the gameobject (wheel). isKinematic = true, wheel is not affected by physics (gravity or collisons). Wheel will be 'frozen' in current position and rotation.
        }
        else
        {
            Debug.LogError("No camera found!");
        }
    }

    

    private void OnMouseUp()                                                                         //Whenever mouse button is released and when the dragging stops
    {
        
        dragged = false;
        
        
        GetComponent<Rigidbody2D>().isKinematic = false;
        Debug.Log("Mouse up");

        dragEndedCallback(this);                                                                    //refers to SnapWheel script
    }

    private void Update()
    {
        if (dragged && assignedCamera != null)
        {
                                                                                                     // Get the mouse position in world point without using ScreenToWorldPoint
            Vector3 mousePosition = assignedCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)                                                     
    {
        Debug.Log("We have collided");

        trigged = true;
    }

  void OnTriggerStay2D(Collider2D collison)
    {
        Debug.Log("We are still colliding");

        Destroy(Nutrition, 5f);
        Destroy(NutritionBack, 5f);

        Invoke("StopTrigged", 6.5f);                                                                  //ChatGpt helped

    }

    void StopTrigged()
    {
        trigged = false;
    }
}
