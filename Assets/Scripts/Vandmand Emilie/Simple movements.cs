using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplemovements : MonoBehaviour
{

    public float speed;
    //the speed at which the object moves (horizontally)
    private float Move;

    private Rigidbody2D rb;
    // rb refers to the rigidbody :)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //first we tell the computer to please remember that the object is a rigidbody
    }

 
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        //Input is a handy class that gets information from keys/mouse/ect
        //GetAxis is a method that gets the value of an axis we identify by a given string(speach-bubble)

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

    }
    //https://youtube.com/shorts/Azh5QuGLDcU?si=6A7AmDyT_-7ZBKiO
}
