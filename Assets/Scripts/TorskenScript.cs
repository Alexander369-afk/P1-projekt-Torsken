using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torsken : MonoBehaviour
{
    public float spd = 8f;
    private Rigidbody2D rb;
    public static int sceneCount = 1;
    private bool sceneFourExecuted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //fra CHATGPT --> 
    IEnumerator CountDownTimer()
    {
        float timer = 5f; // Set the initial timer value to 5 seconds

        while (timer > 0f)
        {
            // Decrease the timer by the time elapsed since the last frame
            timer -= Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        sceneCount = sceneCount + 1;
        Debug.Log("har snakket med bakterie");
        //Debug.Log(sceneCount);
    }
    //indtil her
    bool IsColliding()
    {
        // Check if colliding with any Collider
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale, 0);
        return collider != null;
    }

    void Update()
    {
        if (sceneCount == 1)
        {
            transform.Translate(Vector2.right * spd * Time.deltaTime);
        }

        if (sceneCount == 4)
        {
            spd = 15f;
            transform.Translate(new Vector2(spd * Time.deltaTime, 0.0001f));

        }

        if (sceneCount == 5)
        {
            transform.Translate(new Vector2(spd * Time.deltaTime, 0.005f));
            spd = 1f;
        }

        if (sceneCount == 2)
        {
            StartCoroutine(CountDownTimer());
            Debug.Log("timer er startet");
            sceneCount = sceneCount + 1;
        }
    }

    private void FixedUpdate()
    {
        if (IsColliding() && sceneCount == 1)
        {
            sceneCount = sceneCount + 1;
            // Debug.Log(sceneCount);
        }

        if (IsColliding() && sceneCount == 4)
        {
            sceneCount = sceneCount + 1;
        }

        /**for (int i = 0; i < sceneCount; i++)
        {
            Debug.Log("Scene count is " + sceneCount);
        }**/
    }
}