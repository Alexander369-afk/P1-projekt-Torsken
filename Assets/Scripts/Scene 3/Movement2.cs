using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private Vector2 direction;
    public float moveSpeed;

    private bool selected;
    //this will indicate the object wheter to follow or not


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (selected == true)
        // If the item is selected
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 is an array that contains y/x cordinates of the mouse position (called direction)

            transform.position = new Vector2(cursorPos.x, transform.position.y);
            // move the position to these new cordinates in another array 

            //rb.velocity = new Vector2(moveSpeed, rb.velocity.x);
            //dont know if this works :/
        }

        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
            //the item will no longer follow
        }
    }

    void OnMouseOver()
    //detects if the cursor is over the object (Because of the added 2D box-collider (tjek off 'is trigger'))
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }


    //source: https://www.youtube.com/watch?v=9hTnlp9_wX8 (ChatGPT was used to explain the code)
    //source: https://youtu.be/We1ab6yHrwI?si=MXOWkz12_cQ8ftbZ
}

