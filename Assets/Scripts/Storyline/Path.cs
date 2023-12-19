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
        // Check if the path script should be disabled
        if (!IsPathScriptEnabled())
        {
            return;
        }

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

    // Method to check if the path script should be disabled
    private bool IsPathScriptEnabled()
    {
        // Check if there is a collision with an object tagged as "DisablePathScript"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("DisablePathScript"))
            {
                // Disable the path script and return false
                enabled = false;
                return false;
            }
        }

        // Return true if no disabling collision is detected
        return true;
    }

    public void WheelSnapped()
    {
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
    }
}