using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
   [SerializeField] Transform[] Waypoints= new Transform[10];

   [SerializeField] private float movespeed;

    int nextScene;
    public static int spil1done = 0; //bør være en true/false

    public int waypointsIndex;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.CompareTag("Spil1"))
           // { 
              //  Debug.Log("Canvas touched");
            //if (collision.CompareTag("eyo"))
               // Debug.Log("Canvas EYO");
           // if (collision.CompareTag("YOYO"))
           //     Debug.Log("EYEHO");
        //}
// }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        nextScene = Torsken.sceneCount;
       
        if (nextScene == 8) {
            Debug.Log("Hamna");

            transform.position = Waypoints[waypointsIndex].transform.position;

            if (waypointsIndex <= Waypoints.Length - 1 && nextScene == 8)
            {

                transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointsIndex].transform.position, movespeed * Time.deltaTime);

                if (transform.position == Waypoints[waypointsIndex].transform.position)
                {
                    waypointsIndex += 1;
                }
            } else {
                spil1done++;
                nextScene++;
            }
        }
    }
}
