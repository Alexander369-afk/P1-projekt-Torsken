using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds;
    [SerializeField] private float[] waitTimes;

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
                transform.position = Vector2.MoveTowards(transform.position,
                    Waypoints[waypointsIndex].position, moveSpeeds[waypointsIndex] * Time.deltaTime);
            }

            if (timer >= waitTimes[waypointsIndex])
            {
                timer = 0f;
                waypointsIndex++;
            }
        }
    }

    public void WheelSnapped()
    {
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
    }
}