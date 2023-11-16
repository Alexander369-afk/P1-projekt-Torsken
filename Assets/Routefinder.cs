using UnityEngine;

public class Routefinder : MonoBehaviour
{
    public static Transform [] Waypoints;

    void Awake()
    {
        Waypoints = new Transform[transform.childCount];
        for (int i = 0; i < Waypoints.Length; i++)
        {
           Waypoints[i] = transform.GetChild(i);
        }



    }



}