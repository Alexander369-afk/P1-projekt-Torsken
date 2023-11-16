
using UnityEngine;

public class TorskenMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int currentWaypointIndex = 1;


    void Start ()
    {
        target = Routefinder.Waypoints[6];
        
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


    }


    
}
