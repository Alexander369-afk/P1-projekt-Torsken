using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragDropWheel : MonoBehaviour
{
    // code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);

    public DragEndedDelegate dragEndedCallback;

    public float delay = 2;         //https://gamedevbeginner.com/how-to-delay-a-function-in-unity/ delay on wheel rotate after snap
    private float timer;
    
   

    bool dragged = false;           //variable either being true or false
    bool trigged = false;


    Vector3 offset;

    //Vector3 wheelDragStartPosition;

    //public GameObject Wheel;
    public ParticleSystem Nutrition;
    public ParticleSystem NutritionBack;

    public Vector3 rotateAmount;

    private void OnMouseDown()      //Unity function; whenever mouse button is
                                    //clicked down on an object this function will get called. 
    {
        dragged = true;             //set to true, as this is when we want to drag

        
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //wheelDragStartPosition = transform.localPosition;

        //GetComponent<Rigidbody2D>().isKinematic = true;

    }

    /* private void OnMouseDrag()
     {
         if(dragged) 
         {
             transform.localPosition = wheelDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset);
         }
     }*/

    private void OnMouseUp()      //Whenever mouse button is released 
    {
        Debug.Log("Mouse up");

        dragged = false;

        //GetComponent<Rigidbody2D>().isKinematic = false;

        dragEndedCallback(this);
    }

    private void Update()
    {
        if (dragged)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;


            /* Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos; */

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
