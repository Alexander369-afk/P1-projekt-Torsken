using System;
using UnityEngine;

[Serializable]
public class WaypointAudio
{
    public Collider2D collider;
    public string audioClipName;
    public bool allowAudioLoop; // New variable to control audio looping for each audio clip
    public bool stopAudio; // New variable to control stopping audio for each audio clip
}

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    [SerializeField] private float[] moveSpeeds;
    [SerializeField] private float[] waitTimes;
    [SerializeField] private WaypointAudio[] waypointAudios;

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
                transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointsIndex].position, moveSpeeds[waypointsIndex] * Time.deltaTime);
                audioPlayed = false;
            }
            else
            {
                if (!audioPlayed)
                {
                    if (waypointsIndex < waypointAudios.Length)
                    {
                        AudioManager.instance.Play(waypointAudios[waypointsIndex].audioClipName, waypointAudios[waypointsIndex].allowAudioLoop);
                    }

                    audioPlayed = true;
                }

                timer += Time.deltaTime;

                if (timer >= waitTimes[waypointsIndex])
                {
                    timer = 0f;

                    // Stop audio if specified in waypointAudios
                    if (waypointsIndex < waypointAudios.Length && waypointAudios[waypointsIndex].stopAudio)
                    {
                        AudioManager.instance.Stop(waypointAudios[waypointsIndex].audioClipName);
                    }

                    waypointsIndex++;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int colliderIndex = Array.FindIndex(waypointAudios, wa => wa.collider == other);

        if (colliderIndex != -1 && colliderIndex < waypointAudios.Length)
        {
            AudioManager.instance.Play(waypointAudios[colliderIndex].audioClipName, waypointAudios[colliderIndex].allowAudioLoop);

            // Stop audio if specified in waypointAudios
            if (waypointAudios[colliderIndex].stopAudio)
            {
                AudioManager.instance.Stop(waypointAudios[colliderIndex].audioClipName);
            }

            other.enabled = false;
        }
    }

    public void WheelSnapped()
    {
        waypointsIndex = (waypointsIndex + 1) % Waypoints.Length;
        audioPlayed = false;
    }
}