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

    // Start is called before the first frame update


    void Awake()
    {
        audioManager =FindAnyObjectByType<AudioManager>();

        if(audioManager == null)
        {

            Debug.LogWarning("AudioMangager not found in the scene.");
        }
    }

    void Start()
    {
        audioManager.Play("HighPitchBu");
        waypointsIndex = 0;
        timer = 0f;
    }

    // Update is called once per frame
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
                // Arrived at the waypoint, start waiting
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
}