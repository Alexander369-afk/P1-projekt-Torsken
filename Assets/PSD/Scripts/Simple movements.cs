using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplemovements : MonoBehaviour
{

    public float speed;
    private float Move;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);
    }
    //https://youtube.com/shorts/Azh5QuGLDcU?si=6A7AmDyT_-7ZBKiO
}
