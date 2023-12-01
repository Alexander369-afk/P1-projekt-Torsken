using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //This is based on code from the tutorial linked at the bottom.
    //I have written/ made changes in: 

    public float rotationspeed;
    private Vector2 direction;
    public float moveSpeed;

    private bool canDrag = false;


    private void OnMouseOver()
    {
        Debug.Log("Mouse over");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            canDrag = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            canDrag = false;
        }
    }


    void Update()
    {

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Direction Calculation: Get the direction vector from the current position of the game object to the mouse position on the screen.
        //Camera.main.ScreenToWorldPoint(Input.mousePosition): Converts the mouse position from screen coordinates to a point in the game world.
        //transform.position: Gets the current position of the game object.

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Angle Calculation: Calculate the angle in degrees using Mathf.Atan2, based on the y and x components of the direction vector.
        //Mathf.Atan2(direction.y, direction.x): Calculates the angle in radians based on the y and x components of the direction vector.
        //Mathf.Rad2Deg: Converts the angle from radians to degrees.

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Create a Quaternion: representing the rotation based on the calculated angle around the Z-axis (Vector3.forward).
        //Quaternion.AngleAxis(angle, Vector3.forward): Creates a quaternion rotation around the Z-axis (Vector3.forward) with the specified angle.


        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationspeed * Time.deltaTime);
        //Smooth Rotation
        //Quaternion.Slerp: Performs spherical linear interpolation between two quaternions (current rotation and the target rotation).
        //transform.rotation: The current rotation of the game object.
        //rotation: The target rotation based on the mouse position.
        //rotationspeed * Time.deltaTime: Controls the speed of interpolation, taking into account the frame time.


        //if the curser is cliking down

        if (MouseIsAboveObject())
        {
            Debug.Log("Mouse is above the object!");

        }
        if(canDrag)
        {
        
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("You are holding down the mouse");
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("I found the position:");
                //Input.mousePosition: Retrieves the current mouse position in screen coordinates (measured in pixels).
                //Camera.main.ScreenToWorldPoint(...): Converts the mouse position from screen coordinates
                //Vector2 cursorPos: Stores the converted mouse position in a Vector2

            
                MoveTowards(cursorPos);
            }
        }

        void MoveTowards(Vector2 cursorPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
            // Debug.Log(transform.position);
            //transform.position: Represents the current position of the GameObject to which this script is attached.
            //moveSpeed: A variable that determines the speed at which the GameObject moves towards the mouse cursor.
            //Time.deltaTime: The time in seconds it took to complete the last frame. Multiplying by this value ensures that the movement speed is frame-rate independent.
        }

        //checks it. yes or no?
        bool MouseIsAboveObject()
        {
            // Check if the mouse position is within the object's collider
            return GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //return: the result of the collider.bounds.Contains(...) check is returned by the method (IsMouseAboveObject)
            // GetComponent checks where the Jelly's border/collider is
            //bounds... checks if the world position of the mouse is the same as the colider 
        }

        //source: https://www.youtube.com/watch?v=9hTnlp9_wX8 (ChatGPT was used to explain the code)
    }
}