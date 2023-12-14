using System.Collections;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds; // Array of move speeds for each waypoint
    [SerializeField] private float[] waitTimes;  // Array of wait times for each waypoint

    private float timer;
    private int waypointsIndex;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager not found in the scene.");
        }
    }

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
                transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointsIndex].position, moveSpeeds[waypointsIndex] * Time.deltaTime);
            }
            else
            {
                // Arrived at the waypoint, play audio and start waiting
                if (waypointsIndex == 0)
                {
                    AudioManager.instance.Play("CutScene0");
                }
                else if (waypointsIndex == 1)
                {
                    AudioManager.instance.Play("BakterieSnak");
                }
                else if (waypointsIndex == 4)
                {
                    AudioManager.instance.Play("Spil1Forklaring");
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

    public void WheelSnapped()
    {
        // Implement the logic to handle waypoint change when the wheel is snapped
        // For example, you can increment waypointsIndex or set a specific waypoint index
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
    }
}