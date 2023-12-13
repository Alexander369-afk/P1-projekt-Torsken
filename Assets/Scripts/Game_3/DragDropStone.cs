using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragStone : MonoBehaviour
{
    //code from Youtube https://www.youtube.com/watch?v=1unr2-nR3xE and ChatGPT

    bool dragged = false;           //variable either being true or false

    Vector3 offset;

    private void OnMouseDown()      //Unity function; whenever mouse button is
                                    //clicked down on an object this function will get called. 
    {
        dragged = true;             //set to true, as this is when we want to drag

        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GetComponent<Rigidbody2D>().isKinematic = true;
                
    }

    private void OnMouseUp()      //Whenever mouse button is released 
    {
        Debug.Log("Mouse up");

        dragged = false;        
        
        GetComponent<Rigidbody2D>().isKinematic = false;
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


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (!Pressed && collision.gameObject.layer == LayerMask.NameToLayer("Game_3_stone"))
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        Debug.Log("Stack");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Game_3_stone"))
        {
            //GetComponent<Rigidbody2D>().isKinematic = false;
        }

    }*/

}
