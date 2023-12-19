using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints; // Array that sets a GameObject as a waypoint
    [SerializeField] private float[] moveSpeeds; // Array that sets the move speed from one waypoint to the next
    [SerializeField] private float[] waitTimes;  // Array for amount of seconds Torsken should wait at each waypoint

    private float timer;
    private int waypointsIndex;

    void Start()
    {
        AudioManager.instance.Play("Havlyden Loop");
        waypointsIndex = 0;
        timer = 0f;
    }

    void Update()
    {
        if (waypointsIndex < Waypoints.Length)
        {
            float distance = Vector2.Distance(transform.position, Waypoints[waypointsIndex].position);

            if (distance > 0.1f)
            {
                // Move towards the waypoint with the specified move speed
                transform.position = Vector2.MoveTowards(transform.position,
                    Waypoints[waypointsIndex].position, moveSpeeds[waypointsIndex] * Time.deltaTime);
            }
            
            if (timer >= waitTimes[waypointsIndex])
            {
                // Reset the timer and move to the next waypoint
                timer = 0f;
                waypointsIndex++;
            }
        }
    }

    public void WheelSnapped()
    {
        // Feature for Game 3 where if the wheel is snapped it will update the waypoint index. 
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
        timer = 0f; // Reset timer when changing waypoints
    }
}

