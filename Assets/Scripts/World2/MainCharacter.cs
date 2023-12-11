using System;
using Unity.VisualScripting;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject Circle;
    public GameObject objectToIgnore1;
    public GameObject objectToIgnore2;

    private float rayDistance;
    private Vector2 rayDirection;
    private Vector2 rayOrigin;
    private LayerMask obstacleLayer;

    void Start()
    {
        obstacleLayer = LayerMask.GetMask("RayHit");
        rayDirection = Vector2.right;
        rayDistance = Vector2.Distance(transform.position, Circle.transform.position);
        float distance = Vector2.Distance(transform.position, Circle.transform.position);
        Debug.Log("Distance between transform and Circle: " + distance);
    }

    void Update()
    {
        if (CheckRays())
        {
            MoveCharacter();
        }


    }

    void MoveCharacter()
    {
        Vector2 nextPosition = Vector2.MoveTowards(transform.position, Circle.transform.position, moveSpeed * Time.deltaTime);
        transform.position = nextPosition;
    }

    bool CheckRays()
    {
        string[] ignoreTags = { "IgnoreRay" };  // Add any additional tags to ignore

        // Define ray parameters manually
        Vector2[] rayOrigins = {
            transform.position,
            (Vector2)transform.position + new Vector2(2f, 0f),
            (Vector2)transform.position + new Vector2(5f, 0f),
            (Vector2)transform.position + new Vector2(10f, 0f),
            (Vector2)transform.position + new Vector2(15f, 0f)
        };

        for (int i = 0; i < rayOrigins.Length; i++)
        {
            Vector2 origin = rayOrigins[i];


            RaycastHit2D hit = Physics2D.Raycast(origin, rayDirection, rayDistance, obstacleLayer);

            Debug.Log($"Ray {i + 1} - Origin: {origin}, Direction: {rayDirection}, Hit: {hit.collider != null}");

            if (hit.collider != null)
            {
                if (Array.Exists(ignoreTags, tag => hit.collider.CompareTag(tag)))
                {
                    Debug.Log("Ignoring obstacle: " + hit.collider.gameObject.name);
                }
                else
                {
                    Debug.Log("Obstacle detected: " + hit.collider.gameObject.name);
                    return false; // Obstacle detected, return false
                }
            }

        }

        return true; // Return true only if none of the rays detect an obstacle
    }


}