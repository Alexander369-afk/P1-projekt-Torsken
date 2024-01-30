// https://www.youtube.com/watch?v=oaFJBP4Ld7k&ab_channel=MohammadFaizanKhan
// https://www.youtube.com/watch?v=EwHiMQ3jdHw&ab_channel=MetalStormGames
// https://www.youtube.com/watch?v=RpmQ2xC6gLE&t=69s&ab_channel=MetalStormGames
using System;
using UnityEngine; //unity engine

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

/*public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds;
    [SerializeField] private float[] waitTimes;

    float timer;
    int waypointsIndex;

    void Start()
    {
        AudioManager.instance.Play("Havlyden Loop");
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
        waypointsIndex++;
    }
}*/