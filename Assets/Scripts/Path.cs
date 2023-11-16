using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
   [SerializeField] Transform[] Waypoints;

   [SerializeField] private float movespeed;

    private int waypointsIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Waypoints[waypointsIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointsIndex <= Waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointsIndex].transform.position, movespeed * Time.deltaTime);

            if(transform.position == Waypoints[waypointsIndex].transform.position)
            {
                waypointsIndex += 1;
            }
        }
    }
}
