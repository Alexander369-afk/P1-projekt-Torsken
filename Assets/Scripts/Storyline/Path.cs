using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds; // Array of move speeds for each waypoint
    [SerializeField] private float[] waitTimes;  // Array of wait times for each waypoint
    [SerializeField] private Collider[] audioColliders; // Array of colliders for each waypoint's audio
    [SerializeField] private string[] audioClipNames; // Array of audio clip names for each waypoint

    private float timer;
    private int waypointsIndex;
    private AudioManager audioManager;
    private bool audioPlayed;

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
                    if (waypointsIndex < audioClipNames.Length)
                    {
                        AudioManager.instance.Play(audioClipNames[waypointsIndex]);
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

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is in the audioColliders array
        int colliderIndex = Array.IndexOf(audioColliders, other);

        if (colliderIndex != -1 && colliderIndex < audioClipNames.Length)
        {
            // Player collided with the collider associated with the current waypoint, trigger audio
            AudioManager.instance.Play(audioClipNames[colliderIndex]);
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