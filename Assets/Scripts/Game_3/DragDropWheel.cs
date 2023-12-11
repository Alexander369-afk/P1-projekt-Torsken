using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropWheel : MonoBehaviour
{
    // code from YouTube https://www.youtube.com/watch?v=axW46wCJxZ0 and https://www.youtube.com/watch?v=izag_ZHwOtM&t=100s
    public delegate void DragEndedDelegate(DragDropWheel wheelObject);

    public DragEndedDelegate dragEndedCallback;
    
    
    bool dragged = false;           //variable either being true or false

    Vector3 offset;
    Vector3 wheelDragStartPosition;

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

        }
    }
}
