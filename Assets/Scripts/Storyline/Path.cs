using System;
using UnityEngine;

[Serializable]
public class WaypointAudio
{
    public Collider2D collider;
    public string audioClipName;
}

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds; // Array of move speeds for each waypoint
    [SerializeField] private float[] waitTimes;  // Array of wait times for each waypoint
    [SerializeField] private WaypointAudio[] waypointAudios; // Array of collider and audio clip pairs

    private float timer;
    private int waypointsIndex;
    private bool audioPlayed;

    void Start()
    {
        AudioManager.instance.Play("Havlyden Loop");
        waypointsIndex = 0;
        timer = 0f;
        audioPlayed = false;
    }

    void Update()
    {
        if (waypointsIndex < Waypoints.Length)
        {
            float distance = Vector2.Distance(transform.position, Waypoints[waypointsIndex].position);

            if (distance > 0.1f)
            {
                // Move towards the waypoint with the specified move speed
                transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointsIndex].position, moveSpeeds[waypointsIndex] * Time.deltaTime);

                // Reset audioPlayed flag while moving towards the waypoint
                audioPlayed = false;
            }
            else
            {
                // Arrived at the waypoint, play audio and start waiting
                if (!audioPlayed)
                {
                    if (waypointsIndex < waypointAudios.Length)
                    {
                        AudioManager.instance.Play(waypointAudios[waypointsIndex].audioClipName);
                    }

                    audioPlayed = true; // Set flag to true so audio is not played again
                }

                timer += Time.deltaTime;

                if (timer >= waitTimes[waypointsIndex])
                {
                    // Reset the timer and move to the next waypoint
                    timer = 0f;
                    waypointsIndex++;
                }
            }
        }
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is in the waypointAudios array
        int colliderIndex = Array.FindIndex(waypointAudios, wa => wa.collider == other);

        if (colliderIndex != -1 && colliderIndex < waypointAudios.Length)
        {
            // Player collided with the collider associated with the current waypoint, trigger audio
            AudioManager.instance.Play(waypointAudios[colliderIndex].audioClipName);

            // Disable the collider
            other.enabled = false;
        }
    }

    public void WheelSnapped()
    {
        // Implement the logic to handle waypoint change when the wheel is snapped
        // For example, you can increment waypointsIndex or set a specific waypoint index
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
        audioPlayed = false; // Reset the audioPlayed flag when changing waypoints
    }
}

