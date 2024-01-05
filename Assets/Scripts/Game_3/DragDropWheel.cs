using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragDropWheel : MonoBehaviour
{
    // code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);

    public DragEndedDelegate dragEndedCallback;

   /* public float delay = 2;         //update 4/1-24: bliver ikke brugt alligevel. https://gamedevbeginner.com/how-to-delay-a-function-in-unity/ delay on wheel rotate after snap
    private float timer;*/

    
    Vector3 offset;
    public Camera assignedCamera;


    bool dragged = false;           //variable either being true or false
    bool trigged = false;

    //Vector3 wheelDragStartPosition;

    //public GameObject Wheel;
    public ParticleSystem Nutrition;
    public ParticleSystem NutritionBack;

    public Vector3 rotateAmount;

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

    

    private void OnMouseUp()      //Whenever mouse button is released 
    {
        Debug.Log("Mouse up");
        dragged = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
        

        dragEndedCallback(this);
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


    void OnTriggerEnter2D(Collider2D collision)         //https://www.youtube.com/watch?v=jwEPKY9poa4 bruger ikke alligvel
    {
        Debug.Log("We have collided");

        trigged = true;
    }

  void OnTriggerStay2D(Collider2D collison)
    {
        Debug.Log("We are still colliding");

        Destroy(Nutrition, 5f);
        Destroy(NutritionBack, 5f);

        Invoke("StopTrigged", 6.5f);      //ChatGpt helped

    }

    void StopTrigged()
    {
        trigged = false;
    }
}
